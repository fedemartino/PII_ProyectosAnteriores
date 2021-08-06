using System;
using System.Collections.Generic;
using System.Text;

namespace Drawing.Tests
{
    class MockPoint: IPoint
    {
        private readonly Int32 x;
        private readonly Int32 y;

        public MockPoint(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }

        public Int32 X 
        { 
            get 
            { 
                return x; 
            }                    
        }

        public Int32 Y 
        { 
            get 
            { 
                return y; 
            }            
        }
    }
}
