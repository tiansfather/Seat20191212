﻿// <auto-generated />
using System;
using Master.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Master.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    partial class MasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Master.Application.Editions.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Edition");
                });

            modelBuilder.Entity("Master.Application.Features.FeatureSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int?>("TenantId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.ToTable("FeatureSetting");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FeatureSetting");
                });

            modelBuilder.Entity("Master.Auditing.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrowserInfo");

                    b.Property<string>("ClientIpAddress");

                    b.Property<string>("ClientName");

                    b.Property<string>("CustomData");

                    b.Property<string>("Exception");

                    b.Property<int>("ExecutionDuration");

                    b.Property<DateTime>("ExecutionTime");

                    b.Property<int?>("ImpersonatorTenantId");

                    b.Property<long?>("ImpersonatorUserId");

                    b.Property<string>("MethodName");

                    b.Property<string>("Parameters");

                    b.Property<string>("ServiceName");

                    b.Property<int?>("TenantId");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "ExecutionDuration");

                    b.HasIndex("TenantId", "ExecutionTime");

                    b.HasIndex("TenantId", "UserId");

                    b.ToTable("AuditLog");
                });

            modelBuilder.Entity("Master.Authentication.PermissionSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsGranted");

                    b.Property<string>("Name");

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Name");

                    b.ToTable("Permissions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PermissionSetting");
                });

            modelBuilder.Entity("Master.Authentication.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsStatic");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Master.Authentication.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Email");

                    b.Property<string>("ExtensionData");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastLoginTime");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<DateTime?>("LockoutEndDate");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Sex")
                        .HasMaxLength(2);

                    b.Property<string>("Status");

                    b.Property<int?>("TenantId");

                    b.Property<string>("UserName");

                    b.Property<string>("WorkLocation");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Master.Authentication.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("TenantId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Master.Authentication.UserLoginAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrowserInfo");

                    b.Property<string>("ClientIpAddress");

                    b.Property<string>("ClientName");

                    b.Property<DateTime>("CreationTime");

                    b.Property<byte>("Result");

                    b.Property<string>("TenancyName");

                    b.Property<int?>("TenantId");

                    b.Property<long?>("UserId");

                    b.Property<string>("UserNameOrPhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "TenantId");

                    b.HasIndex("TenancyName", "UserNameOrPhoneNumber", "Result");

                    b.ToTable("UserLoginAttempt");
                });

            modelBuilder.Entity("Master.Authentication.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int>("RoleId");

                    b.Property<int?>("TenantId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("TenantId", "RoleId");

                    b.HasIndex("TenantId", "UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Master.Configuration.Dictionaries.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<string>("DictionaryContent");

                    b.Property<string>("DictionaryName");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("Master.Configuration.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("TenantId");

                    b.Property<long?>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Name");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Master.Module.ColumnInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnKey");

                    b.Property<string>("ColumnName");

                    b.Property<int>("ColumnType");

                    b.Property<string>("ControlFormat");

                    b.Property<string>("ControlParameter");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("CustomizeControl");

                    b.Property<string>("DefaultValue");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DictionaryName");

                    b.Property<string>("DisplayFormat");

                    b.Property<string>("DisplayPath");

                    b.Property<bool>("EnableFieldPermission");

                    b.Property<string>("ExtensionData");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEnableSort");

                    b.Property<bool>("IsInterColumn");

                    b.Property<bool>("IsShownInAdd");

                    b.Property<bool>("IsShownInAdvanceSearch");

                    b.Property<bool>("IsShownInEdit");

                    b.Property<bool>("IsShownInList");

                    b.Property<bool>("IsShownInMultiEdit");

                    b.Property<bool>("IsShownInView");

                    b.Property<bool>("IsSystemColumn");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("MaxFileNumber");

                    b.Property<int>("ModuleInfoId");

                    b.Property<string>("RelativeDataString");

                    b.Property<int>("RelativeDataType");

                    b.Property<string>("Renderer");

                    b.Property<int>("Sort");

                    b.Property<string>("Templet");

                    b.Property<int>("TenantId");

                    b.Property<string>("ValuePath");

                    b.Property<string>("VerifyRules");

                    b.HasKey("Id");

                    b.HasIndex("ModuleInfoId");

                    b.ToTable("ColumnInfo");
                });

            modelBuilder.Entity("Master.Module.ModuleButton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ButtonActionParam");

                    b.Property<int>("ButtonActionType");

                    b.Property<string>("ButtonActionUrl");

                    b.Property<string>("ButtonClass");

                    b.Property<string>("ButtonKey");

                    b.Property<string>("ButtonName");

                    b.Property<string>("ButtonScript");

                    b.Property<int>("ButtonType");

                    b.Property<string>("ClientShowCondition");

                    b.Property<string>("ConfirmMsg");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("ExtensionData");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsEnabled");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("ModuleInfoId");

                    b.Property<string>("Remarks");

                    b.Property<bool>("RequirePermission");

                    b.Property<int>("Sort");

                    b.Property<int>("TenantId");

                    b.Property<string>("TitleTemplet");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.HasIndex("ModuleInfoId");

                    b.HasIndex("TenantId");

                    b.ToTable("ModuleButton");
                });

            modelBuilder.Entity("Master.Module.ModuleData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("ExtensionData");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int>("ModuleInfoId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.HasIndex("ModuleInfoId");

                    b.ToTable("ModuleData");
                });

            modelBuilder.Entity("Master.Module.ModuleInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int>("DefaultLimit");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("EntityFullName");

                    b.Property<string>("ExtensionData");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsInterModule");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Limits");

                    b.Property<string>("ModuleKey");

                    b.Property<string>("ModuleName");

                    b.Property<string>("RequiredFeature");

                    b.Property<string>("SortField");

                    b.Property<int>("SortType");

                    b.Property<int>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.ToTable("ModuleInfo");
                });

            modelBuilder.Entity("Master.MultiTenancy.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConnectionString");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<int?>("EditionId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name");

                    b.Property<string>("TenancyName");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("EditionId");

                    b.HasIndex("LastModifierUserId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Master.Organizations.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BriefCode");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("DisplayName")
                        .IsRequired();

                    b.Property<string>("ExtensionData");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Remarks");

                    b.Property<int>("Sort");

                    b.Property<int>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("DeleterUserId");

                    b.HasIndex("LastModifierUserId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TenantId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Master.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Remarks");

                    b.Property<int>("SeatNumber");

                    b.HasKey("Id");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("Master.SeatOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int>("Day");

                    b.Property<int>("Month");

                    b.Property<string>("OrderOpenId");

                    b.Property<int>("SeatNumber");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("SeatOrder");
                });

            modelBuilder.Entity("Master.Application.Features.EditionFeatureSetting", b =>
                {
                    b.HasBaseType("Master.Application.Features.FeatureSetting");

                    b.Property<int>("EditionId");

                    b.HasIndex("EditionId");

                    b.HasDiscriminator().HasValue("EditionFeatureSetting");
                });

            modelBuilder.Entity("Master.Application.Features.TenantFeatureSetting", b =>
                {
                    b.HasBaseType("Master.Application.Features.FeatureSetting");

                    b.HasDiscriminator().HasValue("TenantFeatureSetting");
                });

            modelBuilder.Entity("Master.Authentication.RolePermissionSetting", b =>
                {
                    b.HasBaseType("Master.Authentication.PermissionSetting");

                    b.Property<int>("RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");

                    b.HasDiscriminator().HasValue("RolePermissionSetting");
                });

            modelBuilder.Entity("Master.Authentication.UserPermissionSetting", b =>
                {
                    b.HasBaseType("Master.Authentication.PermissionSetting");

                    b.Property<long>("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");

                    b.HasDiscriminator().HasValue("UserPermissionSetting");
                });

            modelBuilder.Entity("Master.Authentication.PermissionSetting", b =>
                {
                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("Master.Authentication.Role", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");

                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("Master.Authentication.User", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");

                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("Master.Authentication.UserLogin", b =>
                {
                    b.HasOne("Master.Authentication.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Authentication.UserRole", b =>
                {
                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.HasOne("Master.Authentication.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Configuration.Dictionaries.Dictionary", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");

                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Module.ColumnInfo", b =>
                {
                    b.HasOne("Master.Module.ModuleInfo", "ModuleInfo")
                        .WithMany("ColumnInfos")
                        .HasForeignKey("ModuleInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Module.ModuleButton", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");

                    b.HasOne("Master.Module.ModuleInfo", "ModuleInfo")
                        .WithMany("Buttons")
                        .HasForeignKey("ModuleInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Module.ModuleData", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");

                    b.HasOne("Master.Module.ModuleInfo", "ModuleInfo")
                        .WithMany()
                        .HasForeignKey("ModuleInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Module.ModuleInfo", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");
                });

            modelBuilder.Entity("Master.MultiTenancy.Tenant", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Application.Editions.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");
                });

            modelBuilder.Entity("Master.Organizations.Organization", b =>
                {
                    b.HasOne("Master.Authentication.User", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Master.Authentication.User", "DeleterUser")
                        .WithMany()
                        .HasForeignKey("DeleterUserId");

                    b.HasOne("Master.Authentication.User", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");

                    b.HasOne("Master.Organizations.Organization", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Master.MultiTenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Application.Features.EditionFeatureSetting", b =>
                {
                    b.HasOne("Master.Application.Editions.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Authentication.RolePermissionSetting", b =>
                {
                    b.HasOne("Master.Authentication.Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Master.Authentication.UserPermissionSetting", b =>
                {
                    b.HasOne("Master.Authentication.User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
