using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AuthGuard.EntityFrameworkCore.ValueGenerators;

public class DateValueGenerator : ValueGenerator
{
    public override bool GeneratesTemporaryValues => false;

    protected override object NextValue(EntityEntry entry)
    {
        return DateTime.UtcNow;
    }
}