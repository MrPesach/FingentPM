using System;
using RCG.Domain.Entities;

namespace RCG.WPF.State.Accounts
{
    public interface IUserStore
    {
        Users IsAuth { get; set; }
        event Action StateChanged;
    }
}
