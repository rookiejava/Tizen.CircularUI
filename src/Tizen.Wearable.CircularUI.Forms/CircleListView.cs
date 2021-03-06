﻿/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Flora License, Version 1.1 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://floralicense.org/license/
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Tizen.Wearable.CircularUI.Forms
{
    /// <summary>
    /// The CircleListView is a view that represents Xamarin.Forms.ListView on Circular UI.
    /// You can move the list through bezel action.
    /// </summary>
    public class CircleListView : ListView, IRotaryFocusable, ICircleSurfaceConsumer
    {
        /// <summary>
        /// BindableProperty. Identifies the Header, Footer cancel the Fish Eye Effect or not.
        /// </summary>
        public static readonly BindableProperty CancelEffectProperty = BindableProperty.CreateAttached("CancelEffect", typeof(bool), typeof(CircleListView), false);

        /// <summary>
        /// BindableProperty. Identifies color of the scroll bar.
        /// </summary>
        public static readonly BindableProperty BarColorProperty = BindableProperty.CreateAttached("BarColor", typeof(Color), typeof(CircleListView), Color.Default);

        /// <summary>
        /// Gets the Header, Footer cancel the Fish Eye Effect or not.
        /// </summary>
        public static bool GetCancelEffect(BindableObject view) => (bool)view.GetValue(CancelEffectProperty);

        /// <summary>
        /// Sets the Header, Footer cancel the Fish Eye Effect or not.
        /// </summary>
        public static void SetCancelEffect(BindableObject view, bool value) => view.SetValue(CancelEffectProperty, value);


        /// <summary>
        /// Gets or sets a scroll bar color value.
        /// </summary>
        public Color BarColor
        {
            get => (Color)GetValue(BarColorProperty);
            set => SetValue(BarColorProperty, value);
        }

        /// <summary>
        /// Gets or sets a CircleSurfaceProvider.
        /// </summary>
        public ICircleSurfaceProvider CircleSurfaceProvider { get; set; }

        /// <summary>
        /// Event that is raised when a new item is long pressed.
        /// </summary>
        public event EventHandler<ItemLongPressedEventArgs> ItemLongPressed;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyItemLongPressed(object item, int index)
        {
            ItemLongPressed?.Invoke(this, new ItemLongPressedEventArgs(item, index));
        }
    }
}
