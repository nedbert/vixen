﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Common.Controls.TimelineControl.LabeledMarks
{
	public class TimeLineGlobalEventManager
	{
		private static TimeLineGlobalEventManager _manager;

		public event EventHandler<MarksTextChangedEventArgs> MarksTextChanged;
		public event EventHandler<MarksMovedEventArgs> MarksMoved;
		public event EventHandler<MarksMovingEventArgs> MarksMoving;
		public event EventHandler<MarksDeletedEventArgs> DeleteMark;
		public event EventHandler<AlignmentEventArgs> AlignmentActivity;

		private TimeLineGlobalEventManager()
		{
			
		}

		public static TimeLineGlobalEventManager Manager => _manager ?? (_manager = new TimeLineGlobalEventManager());

		public void OnAlignmentActivity(AlignmentEventArgs e)
		{
			AlignmentActivity?.Invoke(this, e);
		}

		public void OnMarkMoved(MarksMovedEventArgs e)
		{
			MarksMoved?.Invoke(this, e);
		}

		public void OnMarksMoving(MarksMovingEventArgs e)
		{
			var t = e.Marks.Select(x => x.Parent).Distinct();
			foreach (var markCollection in t)
			{
				markCollection.EnsureOrder();
			}
			MarksMoving?.Invoke(this, e);
		}

		public void OnDeleteMark(MarksDeletedEventArgs e)
		{
			DeleteMark?.Invoke(this, e);
		}

		public void OnMarksTextChanged(MarksTextChangedEventArgs e)
		{
			MarksTextChanged?.Invoke(this, e);
		}

	}
}
