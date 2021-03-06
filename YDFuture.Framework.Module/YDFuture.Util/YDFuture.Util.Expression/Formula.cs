﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Learun.Util.Expression
{
	using  Learun.Util.Expression.Operand;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using  Learun.Util.Expression.Operator;
    using System.Text.RegularExpressions;

	public class Formula
	{
        public delegate void EvaluateFailedDelegate(string msg);
        private static Dictionary<char, int> GlobalOperatorPrefix = new Dictionary<char, int>();

        private string m_statement = null;
        private int m_curIdx = 0;
        private ExpressionNode m_rootNode = null;

        private ExpressionNode m_lastNode = null;
        private Operand.Operand m_result = null;
        private EvaluateFailedDelegate m_onEvaluateFailed;

        public Formula()
        {
            initOperatorPrefixDictionary();
        }

        public Formula(string statement)
        {
            initOperatorPrefixDictionary();

            Statement = statement;
        }

		public virtual string Statement
		{
            get { return m_statement; }
            set 
            {
                if (m_statement != value)
                {
                    m_statement = value.Trim();

                    if (m_statement.Length > 0 && m_statement[0] == '=')
                        m_statement = m_statement.Substring(1);

                    Parse();
                }
            }
		}

        public EvaluateFailedDelegate OnEvaluateFailed
        {
            get { return m_onEvaluateFailed; }
            set { m_onEvaluateFailed = value; }
        }

        public ExpressionNode ExpressionTree
        {
            get { return m_rootNode; }
        }

		public Operand.Operand Result
		{
			get { return m_result; }
		}

        //////////////////////////////////
        // Utility functions
        //////////////////////////////////
        private void initOperatorPrefixDictionary()
        {
            if (GlobalOperatorPrefix.Count == 0)
            {
                GlobalOperatorPrefix.Add('+', 1);
                GlobalOperatorPrefix.Add('-', 1);
                GlobalOperatorPrefix.Add('*', 1);
                GlobalOperatorPrefix.Add('/', 1);
                GlobalOperatorPrefix.Add('%', 1);
                GlobalOperatorPrefix.Add('>', 1);
                GlobalOperatorPrefix.Add('<', 1);
                GlobalOperatorPrefix.Add('&', 1);
                GlobalOperatorPrefix.Add('|', 1);
                GlobalOperatorPrefix.Add('!', 1);
                GlobalOperatorPrefix.Add('~', 1);
                GlobalOperatorPrefix.Add('^', 1);
            }
        }

        private bool Eof
        {
            get { return m_statement != null && m_curIdx >= m_statement.Length; }
        }

        private char CharAt(int idx)
        {
            return m_statement[idx];
        }

        private char CurChar
        {
            get { return m_statement[m_curIdx]; }
        }

        private bool IsDigit(char ch)
        {
            return (ch >= '0' && ch <= '9') || ch == '.';
        }

        private bool IsLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }

        private bool IsOperatorChar(char ch)
        {
            return GlobalOperatorPrefix.ContainsKey(ch);
        }

        private void SkipSpace()
        {
            while (!Eof)
            {
                if (CurChar != ' ' && CurChar != '\t')
                    break;

                m_curIdx++;
            }
        }

        private string GetNumberString()
        {
            int pos = m_curIdx;
            uint unaryNum = 0;
            uint pointNum = 0;
            uint expNum = 0;

            while (!Eof)
            {
                if (IsDigit(CurChar))
                {
                    if (CurChar == '.')
                    {
                        pointNum++;

                        if (pointNum > 1)
                            break;
                    }
                }
                else
                {
                    if (CurChar == '+' || CurChar == '-')
                    {
                        if (expNum == 0 || unaryNum > 0)
                            break;

                        unaryNum++;
                    }
                    else
                    {
                        if (CurChar == 'E' || CurChar == 'e')
                        {
                            if (expNum > 0)
                                break;

                            expNum++;
                        }
                        else
                            break;
                    }
                }

                m_curIdx++;
            } // while

            if (unaryNum > 1 || pointNum > 1 || expNum > 1)
                throw new System.InvalidOperationException("Invalid number format at pos " + m_curIdx);


            string numStr = m_statement.Substring(pos, m_curIdx - pos);
            Regex rgx = new Regex("\\d+\\.?[Ee][\\+-]\\d+", RegexOptions.IgnoreCase);
            Match match = rgx.Match(numStr);

            if (!match.Success)
            {
                Match tailMatch = (new Regex("\\.\\d", RegexOptions.IgnoreCase)).Match(numStr);
                Match floatMatch = (new Regex("\\d+\\.?\\d*", RegexOptions.IgnoreCase)).Match(numStr);

                if (!tailMatch.Success)
                    match = floatMatch;
                else
                    if (!floatMatch.Success)
                        match = tailMatch;
                    else
                        match = tailMatch.Value.Length > floatMatch.Value.Length ? tailMatch : floatMatch;
            }

            if (!match.Success)
                throw new System.InvalidOperationException("'" + numStr + "' is invalid number.");

            return match.Value;
        }

        private string GetFunctionName()
        {
            Match match = (new Regex("[a-z,\\$]+\\d*", RegexOptions.IgnoreCase)).Match(m_statement.Substring(m_curIdx));

            if (!match.Success)
                throw new System.InvalidOperationException("Invalid function name at pos " + m_curIdx);

            m_curIdx += match.Value.Length;

            return match.Value;
        }

        private string GetContentInParentheses()
        {
            if (Eof || CurChar != '(')
                throw new System.InvalidOperationException("Unmatched '(' at pos " + m_curIdx);

            int num = 0;
            int startPos = m_curIdx;

            while (!Eof)
            {
                if (CurChar == '(')
                    num++;
                else
                {
                    if (CurChar == ')')
                    {
                        num--;

                        if (num == 0)
                            break;
                    }
                }

                m_curIdx++;
            } // while

            if (num < 0)
                throw new System.InvalidOperationException("Unmatched '(' at pos " + m_curIdx);

            string res = m_statement.Substring(startPos + 1, m_curIdx - startPos - 1);

            m_curIdx++;

            return res;

        }

        private string[] GetArgumentArrayFromString(string str)
        {
            List<string> args = new List<string>();
            int pos = 0;
            int parentheses = 0;
            string arg = "";
            char ch;

            while (pos < str.Length)
            {
                ch = str[pos];

                switch (ch)
                {
                    case '(':
                        {
                            parentheses++;
                            arg += ch;
                        }
                        break;
                    case ')':
                        {
                            parentheses--;
                            arg += ch;
                        }
                        break;
                    case ',':
                        {
                            if (parentheses == 0)
                            {
                                args.Add(arg);
                                arg = "";
                            }
                            else
                                arg += ch;
                        }
                        break;
                    default: arg += ch; break;
                }// switch

                pos++;
            } // while

            if (arg.Length > 0)
                args.Add(arg);

            return args.ToArray();
        }

        private void AddOperandNode(Token token)
        {
            if (m_rootNode == null)
            {
                m_rootNode = new ExpressionNode() { Token = token };

                m_lastNode = m_rootNode;
                return;
            }

            if (m_rootNode.Token.IsOperand)
            {
                throw new System.InvalidOperationException("Number should not appear here");
            }

            if (m_rootNode.Token.IsOperator)
            {
                ExpressionNode node = m_rootNode;

                do
                {
                    if (node.Right == null)
                    {
                        node.Right = new ExpressionNode() { Token = token };
                        break;
                    }

                    node = node.Right;

                } while (true);

                m_lastNode = node.Right;
            }
        }
		
        /////////////////////////////////////
        ///     Parse
        /////////////////////////////////////
        private void Parse()
        {
            try
            {
                m_curIdx = 0;
                m_rootNode = null;
                m_lastNode = null;
                m_result = null;

                while (!Eof)
                {
                    switch (CurChar)
                    {
                        case ' ':
                        case '\t': m_curIdx++; break;
                        case '"': ParseString(); break;
                        case '(': ParseParentheses(); break;
                        default:
                            {
                                if (IsLetter(CurChar))
                                    ParseFunction();
                                else
                                    if (IsDigit(CurChar))
                                        ParseNumber();
                                    else
                                        if (IsOperatorChar(CurChar))
                                            ParseOperator();
                                        else
                                            throw new System.InvalidOperationException("Char '" + CurChar + "' not supported.");
                            }
                            break;
                    } // switch
                }
            }
            catch (InvalidOperationException e)
            {
                if (OnEvaluateFailed != null)
                    OnEvaluateFailed.Invoke(e.Message);
            }
        }

        private void ParseNumber()
        {
            Operand.Operand operand = new Operand.Operand(float.Parse(GetNumberString()));

            AddOperandNode(operand);
        }

        private void ParseString()
        {
            int pos = m_curIdx + 1;

            while (pos < m_statement.Length)
            {
                if (CharAt(pos) == '"')
                    break;

                pos++;
            }

            Operand.Operand operand = new Operand.Operand(m_statement.Substring(m_curIdx + 1, pos - m_curIdx - 1));

            AddOperandNode(operand);

            m_curIdx = pos + 1;
        }

        private void ParseOperator()
        {
            Operator.Operator op = null;

            bool isUnary = m_lastNode == null || (m_lastNode != null && (m_lastNode.Token.IsBinary || m_lastNode.Token.IsUnary));

            switch (CurChar)
            {
                case '+':
                    {
                        if (isUnary)
                            op = new Operator.Plus();
                        else
                            op = new Operator.Add();
                    }
                    break;
                case '-':
                    {
                        if (isUnary)
                            op = new Operator.Minus();
                        else
                            op = new Operator.Sub();
                    }
                    break;
                case '~':
                    {
                        if (!isUnary)
                            throw new System.InvalidOperationException("Invalid '~' operator at pos " + m_curIdx);

                        op = new Operator.BitwiseNot();
                    }
                    break;
                case '!':
                    {
                        if (m_curIdx < m_statement.Length - 2 && (CharAt(m_curIdx + 1) == '='))
                            op = new Operator.NotEqual();
                        else
                        {
                            if (!isUnary)
                                throw new System.InvalidOperationException("Invalid '!' operator at pos " + m_curIdx);

                            op = new Operator.Not();
                        }
                    }
                    break;
                case '*': op = new Operator.Mul(); break;
                case '/': op = new Operator.Div(); break;
                case '%': op = new Operator.Mod(); break;
                case '&':
                    {
                        if (m_curIdx < m_statement.Length - 2 && CharAt(m_curIdx + 1) == '&')
                        {
                            op = new Operator.And();
                            m_curIdx++;
                        }
                        else
                        {
                            op = new Operator.BitwiseAnd();
                        }
                    }
                    break;
                case '|':
                    {
                        if (m_curIdx < m_statement.Length - 2 && CharAt(m_curIdx + 1) == '|')
                        {
                            op = new Operator.Or();
                            m_curIdx++;
                        }
                        else
                        {
                            op = new Operator.BitwiseOr();
                        }
                    }
                    break;
                case '>':
                    {
                        if (m_curIdx < m_statement.Length - 1)
                        {
                            switch (CharAt(m_curIdx + 1))
                            {
                                case '=': op = new Operator.GreaterEqual(); m_curIdx++; break;
                                case '>': op = new Operator.ShiftRight(); m_curIdx++; break;
                                default: op = new Operator.Greater(); break;
                            }
                        }
                        else
                            op = new Operator.Greater();
                    }
                    break;
                case '<':
                    {
                        if (m_curIdx < m_statement.Length - 2)
                        {
                            switch (CharAt(m_curIdx + 1))
                            {
                                case '=': op = new Operator.LessEqual(); m_curIdx++; break;
                                case '<': op = new Operator.ShiftLeft(); m_curIdx++; break;
                                default: op = new Operator.Less(); break;
                            }
                        }
                        else
                            op = new Operator.Less();
                    }
                    break;
                case '^': op = new Operator.Xor(); break;
                default: throw new System.InvalidOperationException("Invalid char '" + CurChar + "' at pos " + m_curIdx);
            } // switch

            if (m_lastNode == null)
            {
                m_rootNode = new ExpressionNode() { Token = op };
                m_lastNode = m_rootNode;
            }
            else
            {
                if (m_lastNode.Token.IsOperand)
                {
                    if (m_lastNode == m_rootNode)
                    {
                        ExpressionNode node = new ExpressionNode() { Left = m_rootNode.Copy(), Token = op };
                        m_rootNode = node;
                        m_lastNode = node;
                    }
                    else
                    {
                        // If last node is operand but it isn't the root node, it shall be on the right
                        // branch.
                        ExpressionNode root = m_rootNode;

                        do
                        {
                            if (root.Right == m_lastNode)
                            {
                                ExpressionNode node = new ExpressionNode() { Left = root.Right, Token = op };

                                root.Right = node;
                                m_lastNode = node;
                                break;
                            }

                            root = root.Right;
                        } while (true);
                    }
                }
                else
                {
                    ExpressionNode root = m_rootNode;

                    do
                    {
                        if (op.ComparePriority(root.Token as Operator.Operator) > 0)
                        {
                            if (root.Right == null)
                            {
                                root.Right = new ExpressionNode() { Token = op };
                                m_lastNode = root.Right;
                                break;
                            }
                            else
                            {
                                root = root.Right;
                            }
                        }
                        else
                        {
                            ExpressionNode node = null;

                            if (isUnary)
                                node = new ExpressionNode() { Right = m_rootNode.Copy(), Token = op };
                            else
                            {
                                node = new ExpressionNode() { Left = m_rootNode.Copy(), Token = op };

                                m_rootNode = node;
                            }

                            m_lastNode = node;
                            break;
                        }

                    } while (true);
                }
            }

            m_curIdx++;
        }

        private void ParseFunction()
        {
            if (m_lastNode != null && m_lastNode.Token.IsOperand)
                throw new System.InvalidOperationException("Invalid char '" + CurChar + "' at pos " + m_curIdx);

            string funcName = GetFunctionName();

            if ("true" == funcName.ToLower() || "false" == funcName.ToLower())
            {
                Operand.Operand operand = new Operand.Operand(bool.Parse(funcName));

                AddOperandNode(operand);

                return;
            }

            SkipSpace();

            string[] argArray = GetArgumentArrayFromString(GetContentInParentheses());
            Function func = Function.CreateFunction(funcName);
            ExpressionNode funcNode = new ExpressionNode() { Token = func };

            funcNode.Left = new ExpressionNode() { Token = new Operand.Operand((float)argArray.Count()) };
            ExpressionNode right = funcNode;

            foreach (String argStr in argArray)
            {
                Formula fm = new Formula(argStr);
                ExpressionNode argNode = new ExpressionNode() { Left = fm.ExpressionTree };

                right.Right = argNode;
                right = right.Right;
            }

            if (m_rootNode == null)
                m_rootNode = funcNode;
            else
            {
                if (m_rootNode.Token.IsOperand || m_rootNode.Token.IsFunction)
                {
                    throw new System.InvalidOperationException("Function should not appear here");
                }

                ExpressionNode root = m_rootNode;

                do
                {
                    if (root.Right == null)
                    {
                        root.Right = funcNode;
                        break;
                    }
                    else
                    {
                        root = root.Right;
                    }
                } while (true);
            }

            m_lastNode = funcNode;
        }

        private void ParseParentheses()
        {
            if (m_rootNode != null && m_rootNode.Token.IsOperand)
                throw new System.InvalidOperationException("Invalid '(' at pos " + m_curIdx);

            int num = 1;
            int pos = m_curIdx + 1;
            char ch;

            while (pos < m_statement.Length)
            {
                ch = CharAt(pos);

                if (ch == '(')
                    num++;
                else
                {
                    if (ch == ')')
                    {
                        num--;

                        if (num <= 0)
                            break;
                    }
                }

                pos++;
            } // while

            if (num < 0)
                throw new System.InvalidOperationException("Invalid ')' at pos " + m_curIdx);

            Operator.Operator op = new Operator.Parentheses();
            Formula fm = new Formula(m_statement.Substring(m_curIdx + 1, pos - m_curIdx - 1));
            ExpressionNode node = new ExpressionNode() { Token = op, Right = fm.ExpressionTree };

            m_lastNode = node;

            if (m_rootNode == null)
                m_rootNode = node;
            else
            {
                ExpressionNode root = m_rootNode;

                do
                {
                    if (op.ComparePriority(root.Token as Operator.Operator) > 0)
                    {
                        if (root.Right == null)
                        {
                            root.Right = node;
                            break;
                        }
                        else
                            root = root.Right;
                    }
                    else
                    {
                        node.Right = root;
                        m_rootNode = node;
                        break;
                    }
                } while (true);
            }

            m_curIdx = pos + 1;
        }

        ///////////////////////////
        ///     Evaluate
        ///////////////////////////
        public Operand.Operand Evaluate()
        {
            try
            {
                m_result = EvaluateNode(m_rootNode);
            }
            catch (InvalidOperationException e)
            {
                if (OnEvaluateFailed != null)
                    OnEvaluateFailed.Invoke(e.Message);
            }

            return m_result;
        }

        private Operand.Operand EvaluateNode(ExpressionNode node)
        {
            if (node.Token.IsOperand)
                return node.Token as Operand.Operand;

            // Binary Operator Node
            // Node stores the operator.
            // Left and right leaves are the operands.
            if (node.Token.IsBinary)
            {
                Operator.Operator op = node.Token as Operator.Operator;
                Operand.Operand[] operands = new Operand.Operand[] { 
                    EvaluateNode(node.Left),
                    EvaluateNode(node.Right)
                };

                return op.Evaluate(operands);
            }

            // Unary Operator Node
            // Node stores the operator.
            // It has no left leaf. Its right leaf is the operand.
            if (node.Token.IsUnary)
            {
                Operator.Operator op = node.Token as Operator.Operator;
                Operand.Operand[] operands = new Operand.Operand[] { EvaluateNode(node.Right) };

                return op.Evaluate(operands);
            }

            // Parentheses Operator Node
            // Like Unary operator.
            if (node.Token.IsParentheses)
            {
                return EvaluateNode(node.Right);
            }

            // Function Node
            // Node represents the function.
            // Left leaf is the number of arguments.
            // Right leaf and all children of right leaves are the arguments.
            // Operands or value fileds are the left leaf of arguments.
            if (node.Token.IsFunction)
            {
                Function func = node.Token as Function;
                // Function doesn't need the number of operands.
                Operand.Operand argNum = node.Left.Token as Operand.Operand;
                List<Operand.Operand> operands = new List<Operand.Operand>();

                ExpressionNode right = node.Right;

                do
                {
                    if (right == null)
                        break;

                    operands.Add(EvaluateNode(right.Left));

                    right = right.Right; // next argument
                } while (true);

                return func.Evaluate(operands.ToArray());
            }

            // Others, throw exception.
            throw new System.InvalidOperationException("Unknown operation");
        }
	}
}

