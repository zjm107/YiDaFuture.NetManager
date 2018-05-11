﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Learun.Util.Expression.Operator
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Div : BinaryOperator
	{
        public Div()
            : base("/", PriorityType.MulAndDiv)
        {
        }

        public override Operand.Operand Evaluate(Operand.Operand[] operands)
        {
            base.Evaluate(operands);

            if (operands[1].AsFloat == 0.0f)
                throw new System.InvalidOperationException("Divide by zero");

            return operands[0] / operands[1];
        }
	}
}
