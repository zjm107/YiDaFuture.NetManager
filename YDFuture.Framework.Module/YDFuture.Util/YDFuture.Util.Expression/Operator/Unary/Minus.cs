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

	public class Minus : UnaryOperator
	{
        public Minus()
            : base("-", PriorityType.Unary)
        {
        }

        public override Operand.Operand Evaluate(Operand.Operand[] operands)
        {
            base.Evaluate(operands);

            return new Operand.Operand(-operands[0].AsFloat);
        }
	}
}

