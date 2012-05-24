﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTreeViewer
{
    public static class ExpressionTreeBuilder
    {
        public static ExpressionTreeNode GetExpressionTreeNode(Expression expression, string prefix = null)
        {
            ExpressionTreeNode node = null;
            if (expression is BinaryExpression)
            {
                var expr = expression as BinaryExpression;
                node = new ExpressionTreeNode(string.Format("BinaryExpression: [{0}]", expr.NodeType));
                node.Nodes.Add(GetExpressionTreeNode(expr.Left, "Left"));
                node.Nodes.Add(GetExpressionTreeNode(expr.Right, "Right"));
            }
            if (expression is BlockExpression)
            {
                var expr = expression as BlockExpression;
                node = new ExpressionTreeNode(string.Format("BlockExpression Expressions:"));
                expr.Expressions.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNode(a)));
            }
            if (expression is ConditionalExpression)
            {
                var expr = expression as ConditionalExpression;
                node = new ExpressionTreeNode(string.Format("ConditionalExpression: [{0}]", expr.NodeType));
                node.Nodes.Add(GetExpressionTreeNode(expr.Test, "Test"));
                node.Nodes.Add(GetExpressionTreeNode(expr.IfTrue, "IfTrue"));
                node.Nodes.Add(GetExpressionTreeNode(expr.IfFalse, "IfFalse"));
            }
            if (expression is ConstantExpression)
            {
                var expr = expression as ConstantExpression;
                node = new ExpressionTreeNode(string.Format("ConstantExpression [{0}]: {1}", expr.Type.Name, expr.Value));
            }
            if (expression is DebugInfoExpression)
            {
                var expr = expression as DebugInfoExpression;
            }
            if (expression is DefaultExpression)
            {
                var expr = expression as DefaultExpression;
            }
            if (expression is DynamicExpression)
            {
                var expr = expression as DynamicExpression;
            }
            if (expression is GotoExpression)
            {
                var expr = expression as GotoExpression;
            }
            if (expression is IndexExpression)
            {
                var expr = expression as IndexExpression;
            }
            if (expression is InvocationExpression)
            {
                var expr = expression as InvocationExpression;
            }
            if (expression is LabelExpression)
            {
                var expr = expression as LabelExpression;
            }
            if (expression is LambdaExpression)
            {
                var expr = expression as LambdaExpression;
                node = new ExpressionTreeNode(string.Format("LambdaExpression [{0}] Body:", expr.ReturnType));
                node.Nodes.Add(GetExpressionTreeNode(expr.Body));
            }
            if (expression is ListInitExpression)
            {
                var expr = expression as ListInitExpression;
            }
            if (expression is LoopExpression)
            {
                var expr = expression as LoopExpression;
            }
            if (expression is MemberExpression)
            {
                var expr = expression as MemberExpression;
                node = new ExpressionTreeNode(string.Format("MemberExpression [{0}]: {1}", expr.Type.Name, expr.Member.Name));
            }
            if (expression is MemberInitExpression)
            {
                var expr = expression as MemberInitExpression;
            }
            if (expression is MethodCallExpression)
            {
                var expr = expression as MethodCallExpression;
                node = new ExpressionTreeNode(string.Format("MethodCallExpression [{0}] Arguments:", expr.Method.Name));
                expr.Arguments.ToList().ForEach(a => node.Nodes.Add(GetExpressionTreeNode(a)));
            }
            if (expression is NewArrayExpression)
            {
                var expr = expression as NewArrayExpression;
            }
            if (expression is NewExpression)
            {
                var expr = expression as NewExpression;
                node = new ExpressionTreeNode(string.Format("NewExpression Arguments:"));
                for (int i = 0; i < expr.Arguments.Count; i++)
                    node.Nodes.Add(GetExpressionTreeNode(expr.Arguments[i], expr.Members[i].Name));
            }
            if (expression is ParameterExpression)
            {
                var expr = expression as ParameterExpression;
            }
            if (expression is RuntimeVariablesExpression)
            {
                var expr = expression as RuntimeVariablesExpression;
            }
            if (expression is SwitchExpression)
            {
                var expr = expression as SwitchExpression;
            }
            if (expression is TryExpression)
            {
                var expr = expression as TryExpression;
            }
            if (expression is TypeBinaryExpression)
            {
                var expr = expression as TypeBinaryExpression;
            }
            if (expression is UnaryExpression)
            {
                var expr = expression as UnaryExpression;
                node = new ExpressionTreeNode(string.Format("UnaryExpression [{0}] Oprand:", expr.NodeType));
                node.Nodes.Add(GetExpressionTreeNode(expr.Operand));
            }
            if (node == null)
                node = new ExpressionTreeNode(string.Format("Unkown Node [{0}-{1}]: {2}", expression.GetType().Name, expression.NodeType, expression));
            if (prefix != null)
                node.Text = string.Format("{0} => {1}", prefix, node.Text);
            return node;
        }
    }

    [Serializable]
    public class ExpressionTreeNode
    {
        public ExpressionTreeNode(string text)
        {
            this.Text = text;
            this.Nodes = new List<ExpressionTreeNode>();
        }

        public string Text { get; set; }
        public List<ExpressionTreeNode> Nodes { get; set; }
    }
}