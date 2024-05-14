namespace STW.StubApi.Presentation.Persistence.Configuration;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HttpTransactionConfiguration : IEntityTypeConfiguration<HttpTransaction>
{
    public void Configure(EntityTypeBuilder<HttpTransaction> builder) => builder.HasKey(x => x.Id);
}
