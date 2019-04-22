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
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WearableUIGallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TCSubListPage : CirclePage
    {
        public TCSubListPage()
        {
            InitializeComponent ();
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            if (args.Item == null) return;

            var desc = args.Item as TCDescribe;
            if (desc != null && desc.Class != null)
            {
                Page page;
                if (desc.Class.Count == 1)
                {
                    Type pageType = desc.Class;
                    page = Activator.CreateInstance(pageType) as Page;
                }
                else
                {
                    var types = desc.Class;
                    page = new TCSubListPage();
                    page.BindingContext = types;
                }
                NavigationPage.SetHasNavigationBar(page, false);
                App.MainNavigation.PushAsync(page);
            }
        }
    }

}