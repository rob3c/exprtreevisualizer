using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressionTreeViewer;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockExpression blockExpr = Expression.Block(Expression.Call(null, typeof(Console).GetMethod("Write", new[] { typeof(String) }), Expression.Constant("Hello ")),
               Expression.Call(null, typeof(Console).GetMethod("WriteLine", new[] { typeof(String) }), Expression.Constant("World!")),
               Expression.Constant(42));
            new VisualizerDevelopmentHost(blockExpr, typeof (ExpressionTreeVisualizer), typeof (ExpressionTreeObjectSource)).ShowVisualizer();
        }
    }
}
