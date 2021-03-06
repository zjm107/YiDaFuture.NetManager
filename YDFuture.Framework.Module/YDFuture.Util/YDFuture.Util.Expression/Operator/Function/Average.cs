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
    using  Learun.Util.Expression.Operand;

	public class Average : Function
	{
        private static Function _dummy = new Average();
        
        public Average()
            : base("Average", Operator.PriorityType.Function)
        {
            this.MinArgumentNum = 1;
        }

        public override Operand Evaluate(Operand[] operands)
        {
            base.Evaluate(operands);

            return new Operand(operands.Average(delegate(Operand val) {
                return val.AsFloat;
            }));
        }
	}
}

