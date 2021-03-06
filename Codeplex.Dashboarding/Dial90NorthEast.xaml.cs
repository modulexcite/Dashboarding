﻿//-----------------------------------------------------------------------
// <copyright file="Dial90NorthEast.xaml.cs" company="David Black">
//      Copyright 2008 David Black
//  
//      Licensed under the Apache License, Version 2.0 (the "License");
//      you may not use this file except in compliance with the License.
//      You may obtain a copy of the License at
//     
//          http://www.apache.org/licenses/LICENSE-2.0
//    
//      Unless required by applicable law or agreed to in writing, software
//      distributed under the License is distributed on an "AS IS" BASIS,
//      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//      See the License for the specific language governing permissions and
//      limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Codeplex.Dashboarding
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// A quarter of a circle dial that sweeps through 90 degrees upper right quadrant
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NorthEast", Justification = "too late to fix")]
    public partial class Dial90NorthEast : Dial90
    {
        /// <summary>
        /// Width of the dial face band
        /// </summary>
        private const int FaciaWidth = 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dial90NorthEast"/> class.
        /// </summary>
        public Dial90NorthEast()
        {
            InitializeComponent();
            InitializeDial90();
        }

        /// <summary>
        /// Gets the resource root. This allow us to access the Storyboards in a Silverlight/WPf
        /// neutral manner
        /// </summary>
        /// <value>The resource root.</value>
        protected override FrameworkElement ResourceRoot
        {
            get { return LayoutRoot; }
        }

        /// <summary>
        /// Determines the angle of the needle based on the mouse 
        /// position.
        /// </summary>
        /// <param name="currentPoint">Mouse position</param>
        /// <returns>The angle in degrees</returns>
        protected override double CalculateRotationAngle(Point currentPoint)
        {
            // Adjust for facia

            double opposite = ActualHeight - (currentPoint.Y + FaciaWidth * 2);
            double adjacent = (currentPoint.X - FaciaWidth);
            adjacent = adjacent > 0 ? adjacent : 0;
            double tan = opposite / adjacent;
            double angleInDegrees = Math.Atan(tan) * (180.0 / Math.PI);

            _debug.Text = String.Format("{0:0.00} {1:0.00} {2:0.00}", opposite, adjacent, angleInDegrees);

            return angleInDegrees;
        }

        /// <summary>
        /// Calculate the rotation angle from the normalised actual value
        /// </summary>
        /// <returns>angle in degrees to position the transform</returns>
        protected override double CalculatePointFromNormalisedValue()
        {
            return 90 - (NormalizedValue * 90);
        }

        /// <summary>
        /// Calculate the rotation angle from the normalised current value
        /// </summary>
        /// <returns>angle in degrees to position the transform</returns>
        protected override double CalculatePointFromCurrentNormalisedValue()
        {
            return 90 - (CurrentNormalizedValue * 90);
        }
    }
}
