﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Common;
using MUXControlsTestApp.Utilities;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Linq;
using System.Collections.Generic;
using System;

#if USING_TAEF
using WEX.TestExecution;
using WEX.TestExecution.Markup;
using WEX.Logging.Interop;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
#endif

namespace Windows.UI.Xaml.Tests.MUXControls.ApiTests
{
    [TestClass]
    public class CalendarViewTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            TestUtilities.ClearVisualTreeRoot();
        }

        [TestMethod]
        public void VerifyVisualTree()
        {
            if (PlatformConfiguration.IsOSVersionLessThan(OSVersion.NineteenH1))
            {
                return;
            }

            CalendarView calendarView = null;
            RunOnUIThread.Execute(() =>
            {
                calendarView = new CalendarView();
                calendarView.Width = 400;
                calendarView.Height = 400;
                calendarView.SetDisplayDate(new DateTime(2000, 1, 1));
            });
            TestUtilities.SetAsVisualTreeRoot(calendarView);

            VisualTreeTestHelper.VerifyVisualTree(root: calendarView, masterFilePrefix: "CalendarView");
        }
    }
}