﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandStandard;

namespace Vixen.Module.EffectEditor {
	public interface IEffectEditorModuleDescriptor : IModuleDescriptor {
		/// <summary>
		/// Type id of the command spec module that implements the
		/// command that this control edits.
		/// Guid.Empty if the editor isn't specific to a command.
		/// </summary>
		Guid EffectTypeId { get; }
		/// <summary>
		/// Signature of the commands this control edits.
		/// Null if the editor is specific to a command.
		/// </summary>
		CommandParameterSpecification[] CommandSignature { get; }
	}
}