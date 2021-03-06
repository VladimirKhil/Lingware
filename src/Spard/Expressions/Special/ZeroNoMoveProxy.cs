﻿using Spard.Core;
using Spard.Sources;
using Spard.Transitions;
using System;

namespace Spard.Expressions
{
    internal sealed class ZeroNoMoveProxy: Single
    {
        protected internal override Priorities Priority
        {
            get { return _operand.Priority; }
        }

        protected internal override string Sign
        {
            get { return _operand.Sign; }
        }

        public ZeroNoMoveProxy()
        {

        }

        public ZeroNoMoveProxy(Expression operand)
            : base(operand)
        {

        }

        internal override bool MatchCore(ISource input, ref IContext context, bool next)
        {
            throw new NotImplementedException();
        }

        internal override object Apply(IContext context)
        {
            throw new NotImplementedException();
        }

        internal override TransitionTable BuildTransitionTableCore(TransitionSettings settings, bool isLast)
        {
            var table = _operand.BuildTransitionTable(settings, isLast);

            var result = new TransitionTable();

            foreach (var item in table)
            {
                if (item.Key.Type != InputSetType.Zero)
                {
                    result[item.Key] = item.Value;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return _operand.ToString();
        }

        public override Expression CloneCore()
        {
            return new ZeroMoveProxy();
        }
    }
}
