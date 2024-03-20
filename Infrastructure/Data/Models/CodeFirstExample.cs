using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    internal class CodeFirstExample
    {
    }
}

//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System.Diagnostics.Metrics;
//using ZidPay.Domain.Aggregates.Lookups;
//using ZidPay.Domain.Aggregates.Merchants;
//using ZidPay.Domain.Aggregates.Packagess;

//using ZidPay.Domain.Enums;
//using ZidPay.Shared.Domain.Enums;
//using ZidPay.Shared.Helpers;

//namespace ZidPay.Infrastructure.Persistence.Configurations
//{
//    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
//    {
//        public void Configure(EntityTypeBuilder<Merchant> builder)
//        {
//            builder.Ignore(e => e.DomainEvents);

//            builder.HasIndex(m => new { m.ExternalId });
//            builder.HasIndex(m => new { m.MyFatoorahProviderCode });
//            builder.HasIndex(m => new { m.TapProviderCode });
//            builder.HasIndex(m => new { m.MoyasarProviderCode });

//            builder.HasIndex(m => new { m.ReferenceNumber }).IsUnique();

//            builder.Property(m => m.PaymentProviderId).HasDefaultValue(EnumPaymentProvider.MyFatoorah);
//            builder.Property(m => m.ExternalPaymentProviderId).HasDefaultValue(0);

//            builder.Property(p => p.MerchantStatus).HasConversion(
//                p => p.Id,
//                p => MerchantStatus.FromValue<MerchantStatus>(p));

//            builder.Property(p => p.StatusLastModifiedBy).HasConversion(
//                p => p.Id,
//                p => ModifiedBy.FromValue<ModifiedBy>(p));

//            builder.Property(p => p.SubscriptionStatus).HasConversion(
//                p => p.Id,
//                p => SubscriptionStatus.FromValue<SubscriptionStatus>(p));

//            builder.Property(m => m.MerchantOwnersIDs).HasColumnName("merchant_owners_ids");

//            builder.OwnsOne(m => m.Address, address =>
//            {
//                address.Property(t => t.CountryCode).HasColumnName("country_code").IsRequired();
//                address.HasOne<Country>().WithMany().IsRequired().HasForeignKey(e => e.CountryCode);

//                address.Property(t => t.City).HasColumnName("city").HasMaxLength(1000);
//                address.Property(t => t.District).HasColumnName("district").HasMaxLength(1000);
//                address.Property(t => t.Street).HasColumnName("street").HasMaxLength(1000);
//            });

//            builder.OwnsOne(m => m.OwnerInformation, owner =>
//            {
//                owner.Property(t => t.OwnerFullName).HasColumnName("owner_fullname").HasMaxLength(200);
//                owner.Property(t => t.IdNumber).HasColumnName("id_number").HasMaxLength(50);
//                owner.Property(t => t.Email).HasColumnName("email").HasMaxLength(200);
//                owner.Property(t => t.MobileNumber).HasColumnName("mobile_number").HasMaxLength(50);
//            });

//            builder.OwnsOne(m => m.OrganizationInformation, org =>
//            {
//                org.Property(t => t.OrganizationName).HasColumnName("organization_name").HasMaxLength(200);
//                org.Property(t => t.CommercialName).HasColumnName("commercial_name").IsRequired().HasDefaultValue("").HasMaxLength(200);
//                org.Property(t => t.SmsDisplayName).HasColumnName("sms_display_name").IsRequired().HasDefaultValue("ZidPay").HasMaxLength(200);
//                org.Property(t => t.Link).HasColumnName("link").HasMaxLength(250);
//                org.Property(t => t.CrNumber).HasColumnName("cr_number").HasMaxLength(50);
//                org.Property(t => t.VatNumber).HasColumnName("vat_number").HasMaxLength(50);
//                org.Property(t => t.Logo).HasColumnName("logo").HasMaxLength(200);

//                org.HasIndex(t => new { t.Link });
//            });

//            builder.OwnsOne(m => m.MerchantKyc, org =>
//            {
//                org.Property(p => p.MyFatoorahKycStatus).HasConversion(
//                    p => p.Id,
//                    p => BaseEnumeration.FromValue<KycStatus>(p)).HasColumnName("my_fatoorah_kyc_status").IsRequired(false);

//                org.Property(p => p.MoyasarKycStatus).HasConversion(
//                    p => p.Id,
//                    p => BaseEnumeration.FromValue<KycStatus>(p)).HasColumnName("moyasar_kyc_status").IsRequired(false);

//                org.Property(p => p.TapKycStatus).HasConversion(
//                    p => p.Id,
//                    p => BaseEnumeration.FromValue<KycStatus>(p)).HasColumnName("tap_kyc_status").IsRequired(false);



//                org.Property(t => t.MerchantMyFatoorahRejectionReasons).HasColumnName("my_fatoorah_rejection_reasons").IsRequired(false);
//                org.Property(t => t.MerchantTapRejectionReasons).HasColumnName("tap_rejection_reasons").IsRequired(false);
//                org.Property(t => t.MerchantMoyasarRejectionReasons).HasColumnName("moyasar_rejection_reasons").IsRequired(false);
//                org.Property(t => t.MerchantMoyasarDetailedRejectionReasons).HasColumnName("moyasar_detailed_rejection_reasons").IsRequired(false);

//                org.Property(t => t.MyFatoorahComment).HasColumnName("my_fatoorah_comment").IsRequired(false);
//                org.Property(t => t.TapComment).HasColumnName("tap_comment").IsRequired(false);
//                org.Property(t => t.MoyasarComment).HasColumnName("moyasar_comment").IsRequired(false);
//                org.Property(t => t.WebhookRejection).HasColumnName("webhook_rejection").HasDefaultValue(false);

//                org.Property(t => t.MyFatoorahKycRejectionDate).HasColumnName("my_fatoorah_Kyc_rejection_date").IsRequired(false).IsRequired(false);
//                org.Property(t => t.TapKycRejectionDate).HasColumnName("tap_Kyc_rejection_date").IsRequired(false).IsRequired(false);
//                org.Property(t => t.MoyasarKycRejectionDate).HasColumnName("moyasar_kyc_rejection_date").IsRequired(false).IsRequired(false);

//                org.Property(t => t.MerchantComment).HasColumnName("merchant_comment").IsRequired(false);

//                org.Property(p => p.AccountType).HasConversion(
//                    p => p.Id,
//                    p => BaseEnumeration.FromValue<AccountType>(p));

//                org.Property(t => t.PackageId).HasColumnName("package_id").IsRequired();
//                // org.HasOne<Package>().WithMany().IsRequired().HasForeignKey(e => e.PackageId);

//                org.Property(t => t.StoreCategoryId).HasColumnName("store_category_id").IsRequired();
//                org.HasOne<StoreCategory>().WithMany().IsRequired().HasForeignKey(e => e.StoreCategoryId);

//                org.Property(t => t.AccountType).HasColumnName("account_type").IsRequired();
//                org.Property(t => t.ExpectedTransactionsPerMonth).HasColumnName("expected_transactions_per_month").IsRequired();
//                org.Property(t => t.ExpectedTransactionsVolumePerMonth).HasColumnName("expected_transactions_volume_per_month").IsRequired();
//            });

//            // MerchantBank
//            builder.OwnsMany(m => m.Banks, banks =>
//            {
//                banks.ToTable("merchant_banks");
//                banks.WithOwner().HasForeignKey("merchant_id");
//                banks.Property(b => b.BankIban).HasColumnName("bank_iban").IsRequired();
//                banks.Property(b => b.BankId).HasColumnName("bank_id").IsRequired();
//                banks.Property(b => b.AccountNumber).HasColumnName("account_number").IsRequired();
//                banks.Property(b => b.CardHolderName).HasColumnName("card_holder_name").IsRequired();
//                banks.Property(b => b.IsActive).HasColumnName("is_active").IsRequired().HasDefaultValue(true);
//                banks.Property(b => b.ActivationDate).HasColumnName("activation_date").IsRequired();
//            });

//            // Merchant Attachment
//            builder.OwnsMany(m => m.Attachments, attachments =>
//            {
//                attachments.ToTable("merchant_attachments");
//                attachments.WithOwner().HasForeignKey("merchant_id");
//                attachments.Property(a => a.Url).HasColumnName("url").IsRequired();
//                attachments.Property(a => a.BlobName).HasColumnName("blob_name").IsRequired();
//                attachments.Property(a => a.VersionId).HasColumnName("version_id").IsRequired();
//                attachments.Property(a => a.FileName).HasColumnName("file_name").IsRequired();
//                attachments.Property(a => a.Type).IsRequired().HasConversion(
//                    p => p.Id,
//                    p => BaseEnumeration.FromValue<MerchantAttachmentType>(p));
//            });

//            builder.OwnsOne(m => m.PaymentLinkInfo, paymentLinkInfo =>
//            {
//                paymentLinkInfo.Property(t => t.ActivatedChannels).HasColumnName("activated_channels");
//                paymentLinkInfo.Property(t => t.Reminder).HasColumnName("reminder").HasDefaultValue(false);
//                paymentLinkInfo.Property(t => t.ReminderChannel).HasColumnName("reminder_channel");
//                paymentLinkInfo.Property(t => t.ReminderPeriods).HasColumnName("reminder_periods");
//            });
//        }
//    }
//}




