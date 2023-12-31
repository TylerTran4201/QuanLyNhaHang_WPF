﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Dialogs.Service
{
    public abstract class DialogViewModelBase<T> {
        public string Title { get; set; }
        public string Message { get; set; }
        public T DialogResult { get; set; }

        public DialogViewModelBase() : this(string.Empty, string.Empty) { }
        public DialogViewModelBase(string title) : this(title, string.Empty) { }
        public DialogViewModelBase(string tittle, string message) {
            Title = Title;
            Message = message;
        }
        public void CloseDialogWithResult(IDialogWindow dialog, T result) {
            DialogResult = result;

            if (dialog != null) {
                dialog.DialogResult = true;
            }
        }
    }
}
