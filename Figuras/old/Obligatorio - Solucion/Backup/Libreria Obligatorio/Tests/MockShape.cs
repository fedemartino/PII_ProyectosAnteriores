using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing.Tests
{
    class MockShape: IShape
    {
        private IPoint[] points;

        public IPoint[] Points
        {
            get
            {
                return points;        
            }
            set
            {
                points = value;
            }
        }
        
    }
}
