﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Intrinsic
{
	/// <summary>
	/// Memcpy256
	/// </summary>
	internal sealed class Memcpy256 : IIntrinsicPlatformMethod
	{
		#region Methods

		/// <summary>
		/// Replaces the intrinsic call site
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="typeSystem">The type system.</param>
		void IIntrinsicPlatformMethod.ReplaceIntrinsicCall(Context context, MethodCompiler methodCompiler)
		{
			var dest = context.Operand1;
			var src = context.Operand2;

			var v0 = methodCompiler.CreateVirtualRegister(methodCompiler.TypeSystem.BuiltIn.Void);
			var v1 = methodCompiler.CreateVirtualRegister(methodCompiler.TypeSystem.BuiltIn.Void);
			var zero = Operand.CreateConstant(0, methodCompiler.TypeSystem);
			var offset16 = Operand.CreateConstant(16, methodCompiler.TypeSystem);

			context.SetInstruction(X86.MovupsLoad, v0, dest, zero);
			context.AppendInstruction(X86.MovupsLoad, v1, dest, offset16);
			context.AppendInstruction(X86.MovupsStore, null, dest, zero, v0);
			context.AppendInstruction(X86.MovupsStore, null, dest, offset16, v1);
		}

		#endregion Methods
	}
}
