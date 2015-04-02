using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Entities.Common
{
    public enum EntityType
    {
        Guest = 1,
        User,
        Admin,
        Root,
        Enterprise,
        Bannished,
        Page = 10,
        Ad,
        CentreOfInterest = 100,
        ProCategory,
        Profession
    }

    public enum LinkType
    {
        Friend = 1,
        Creator,
        Admin,
        Contributor,
        Like = 20,
        Bannish = 30,
        AllowToRead,
        AllowToComment,
        AllowToUpdate,
        AllowToCreate,
        AllowToAdmin,
        ProCategory = 101,
        Profession
    }

    public enum LinkStatus
    {
        Demand = 10,
        Confirmed,
        Refused
    }

    public enum MessageType
    {
        Message = 1,
        Comment,
        Article,
        LinkMessage
    }

    public enum Visibility
    {
        Public = 1,
        Link,
        Protected,
        Private,
        Special
    }
}
