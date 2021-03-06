// The MIT License (MIT)
//
// Copyright (c) 2015 FPT Software
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

﻿
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Binding.BindingContext;
using FSoft.WordApp.Core.Models;
using CoreGraphics;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace FSoft.WordApp.IOS.Views
{
	public partial class PostCommentViewCell : MvxTableViewCell//MvxMDTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("PostCommentViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("PostCommentViewCell");

		public PostCommentViewCell (IntPtr handle) : base (handle)
		{
			this.DelayBind(() => {
				this.CreateBindingSet<PostCommentViewCell, Comment>().Bind(lbUserCaption).To(item => item.UserCapitalize).Apply();
				this.CreateBindingSet<PostCommentViewCell, Comment>().Bind(lbUsername).To(item => item.Name).Apply();
				this.CreateBindingSet<PostCommentViewCell, Comment>().Bind(lbTime).To(item => item.Date).WithConversion("TimeAgo").Apply();
				this.CreateBindingSet<PostCommentViewCell, Comment>().Bind(lbComment).To(item => item.Content).Apply();
			});

		}

		public static PostCommentViewCell Create ()
		{
			return (PostCommentViewCell)Nib.Instantiate (null, null) [0];
		}

	}
}

