using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetcowsay
{
    public static class Cow
    {
        public static string GetCow()
        {
            var cow = @"         \  ^__^
          \ (oo)\_______
	    (__)\       )\/\
	        ||----w |
	        ||     ||
		";
            return cow;
        }
    }
}