﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vixen.Sys {
	public abstract class Log {
		public event EventHandler<LogItemEventArgs> ItemLogged;

		protected Log(string name) {
			Name = name;
		}
		
		public string Name { get; private set; }

		public virtual void Write(string qualifyingMessage, Exception ex) {
			string text = qualifyingMessage + ":" + Environment.NewLine + ex.Message + Environment.NewLine;
			while(ex.InnerException != null) {
				text += ex.InnerException.Message + Environment.NewLine;
				ex = ex.InnerException;
			}
			Write(text);
		}

		public virtual void Write(Exception ex) {
			string text = ex.Message + Environment.NewLine;
			while(ex.InnerException != null) {
				text += ex.InnerException.Message + Environment.NewLine;
				ex = ex.InnerException;
			}
			Write(text);
		}

		public virtual void Write(string text) {
			text = "[" + DateTime.Now + "]" + Environment.NewLine + text + Environment.NewLine;
			OnItemLogged(text);
		}

		protected virtual void OnItemLogged(string text) {
			if(ItemLogged != null) {
				ItemLogged(this, new LogItemEventArgs(text));
			}
		}
	}
}