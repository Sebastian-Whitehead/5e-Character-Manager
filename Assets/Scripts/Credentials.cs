/*File for storing user specific information that should not be pushed to github
> git update-index --assume-unchanged Credentials.cs 
> git update-index --no-assume-unchanged Credentials.cs         // Undo the undo credentials github ignore.
*/

namespace Credentials
{
    public class Credentials
    {
        public const string ApiKey = "Your API Key";
    }

    public class FileLocation
    {
        
    }
}
