/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/
using System.Linq.Expressions;

namespace STB.Core
{
    public static class ExpressionExtensions
    {
        public static Expression RemoveUnary(this Expression body)
        {
            return body is UnaryExpression uniary ? uniary.Operand : body;
        }
    }
}