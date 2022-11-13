using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.enginev2.Migrations
{
    /// <inheritdoc />
    public partial class AddLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "application_category_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_category_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application_packages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    uid = table.Column<string>(type: "text", nullable: false),
                    lastupdate = table.Column<string>(name: "last_update", type: "text", nullable: true),
                    version = table.Column<string>(type: "text", nullable: false),
                    rebootrequired = table.Column<bool>(name: "reboot_required", type: "boolean", nullable: false),
                    lcid = table.Column<string>(type: "text", nullable: false),
                    cpuarch = table.Column<string>(name: "cpu_arch", type: "text", nullable: true),
                    filename = table.Column<string>(type: "text", nullable: true),
                    sha256 = table.Column<string>(type: "text", nullable: true),
                    followuri = table.Column<string>(name: "follow_uri", type: "text", nullable: true),
                    absoluteuri = table.Column<string>(name: "absolute_uri", type: "text", nullable: true),
                    executable = table.Column<string>(type: "text", nullable: true),
                    installcmd = table.Column<string>(name: "install_cmd", type: "text", nullable: true),
                    installargs = table.Column<string>(name: "install_args", type: "text", nullable: true),
                    installscript = table.Column<string>(name: "install_script", type: "text", nullable: true),
                    displayname = table.Column<string>(name: "display_name", type: "text", nullable: true),
                    displaypublisher = table.Column<string>(name: "display_publisher", type: "text", nullable: true),
                    displayversion = table.Column<string>(name: "display_version", type: "text", nullable: true),
                    packagedetection = table.Column<string>(name: "package_detection", type: "text", nullable: true),
                    detectvalue = table.Column<string>(name: "detect_value", type: "text", nullable: true),
                    detectscript = table.Column<string>(name: "detect_script", type: "text", nullable: true),
                    uninstallprocess = table.Column<string>(name: "uninstall_process", type: "text", nullable: true),
                    uninstallcmd = table.Column<string>(name: "uninstall_cmd", type: "text", nullable: true),
                    uninstallargs = table.Column<string>(name: "uninstall_args", type: "text", nullable: true),
                    uninstallscript = table.Column<string>(name: "uninstall_script", type: "text", nullable: true),
                    transfermethod = table.Column<string>(name: "transfer_method", type: "text", nullable: false),
                    locale = table.Column<string>(type: "text", nullable: false),
                    uripath = table.Column<string>(name: "uri_path", type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    dependson = table.Column<string[]>(name: "depends_on", type: "text[]", nullable: false),
                    virustotalscanresultsid = table.Column<int>(name: "virus_total_scan_results_id", type: "integer", nullable: true),
                    exploitreportid = table.Column<int>(name: "exploit_report_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application_packages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    uid = table.Column<string>(type: "text", nullable: false),
                    lastupdate = table.Column<string>(name: "last_update", type: "text", nullable: false),
                    applicationcategory = table.Column<string>(name: "application_category", type: "text", nullable: false),
                    publisher = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false),
                    copyright = table.Column<string>(type: "text", nullable: false),
                    licenseacceptrequired = table.Column<bool>(name: "license_accept_required", type: "boolean", nullable: false),
                    lcid = table.Column<string[]>(type: "text[]", nullable: false),
                    cpuarch = table.Column<string[]>(name: "cpu_arch", type: "text[]", nullable: false),
                    homepage = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    docs = table.Column<string>(type: "text", nullable: false),
                    license = table.Column<string>(type: "text", nullable: false),
                    tags = table.Column<string[]>(type: "text[]", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appx_provisioned_packages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    displayname = table.Column<string>(name: "display_name", type: "text", nullable: false),
                    arch = table.Column<string[]>(type: "text[]", nullable: false),
                    lcid = table.Column<string[]>(type: "text[]", nullable: false),
                    supportedwindowsversions = table.Column<string[]>(name: "supported_windows_versions", type: "text[]", nullable: false),
                    supportedwindowseditions = table.Column<string[]>(name: "supported_windows_editions", type: "text[]", nullable: false),
                    supportedwindowsreleases = table.Column<string[]>(name: "supported_windows_releases", type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appx_provisioned_packages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "base_image_file_type_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    filetype = table.Column<string>(name: "file_type", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_base_image_file_type_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "base_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    sizemb = table.Column<int>(name: "size_mb", type: "integer", nullable: false),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string[]>(type: "text[]", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false),
                    cpuarch = table.Column<string>(name: "cpu_arch", type: "text", nullable: true),
                    windowslcid = table.Column<string[]>(name: "windows_lcid", type: "text[]", nullable: false),
                    fido = table.Column<bool>(type: "boolean", nullable: false),
                    baseimagefiletype = table.Column<string>(name: "base_image_file_type", type: "text", nullable: true),
                    locale = table.Column<string>(type: "text", nullable: true),
                    transfermethod = table.Column<string>(name: "transfer_method", type: "text", nullable: true),
                    sha256 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_base_images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cpu_arch_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    arch = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cpu_arch_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driver_cores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    uid = table.Column<string>(type: "text", nullable: false),
                    originalequipmentmanufacturer = table.Column<string>(name: "original_equipment_manufacturer", type: "text", nullable: false),
                    make = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    productionyear = table.Column<int>(name: "production_year", type: "integer", nullable: true),
                    cpuarch = table.Column<string[]>(name: "cpu_arch", type: "text[]", nullable: false),
                    windowsos = table.Column<string[]>(name: "windows_os", type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_driver_cores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    uid = table.Column<string>(type: "text", nullable: false),
                    originalequipmentmanufacturer = table.Column<string>(name: "original_equipment_manufacturer", type: "text", nullable: false),
                    make = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    cspversion = table.Column<string>(name: "csp_version", type: "text", nullable: true),
                    cspname = table.Column<string>(name: "csp_name", type: "text", nullable: true),
                    version = table.Column<string>(type: "text", nullable: false),
                    biosversion = table.Column<string>(name: "bios_version", type: "text", nullable: false),
                    productionyear = table.Column<int>(name: "production_year", type: "integer", nullable: true),
                    cpuarch = table.Column<string[]>(name: "cpu_arch", type: "text[]", nullable: false),
                    oeminstallclass = table.Column<string>(name: "oem_install_class", type: "text", nullable: false),
                    x64 = table.Column<bool>(type: "boolean", nullable: false),
                    x86 = table.Column<bool>(type: "boolean", nullable: false),
                    arm64 = table.Column<bool>(type: "boolean", nullable: true),
                    aarch32 = table.Column<bool>(type: "boolean", nullable: true),
                    uri = table.Column<string>(type: "text", nullable: false),
                    outfile = table.Column<string>(name: "out_file", type: "text", nullable: false),
                    latest = table.Column<bool>(type: "boolean", nullable: false),
                    lastupdate = table.Column<string>(name: "last_update", type: "text", nullable: true),
                    windowsrelease = table.Column<string>(name: "windows_release", type: "text", nullable: false),
                    supportedwindowsversion = table.Column<string[]>(name: "supported_windows_version", type: "text[]", nullable: false),
                    urlvtscan = table.Column<string>(name: "url_vt_scan", type: "text", nullable: true),
                    exploitreportid = table.Column<int>(name: "exploit_report_id", type: "integer", nullable: true),
                    wmiobjectname = table.Column<string>(name: "wmi_object_name", type: "text", nullable: false),
                    wmiobjectvendor = table.Column<string>(name: "wmi_object_vendor", type: "text", nullable: false),
                    wmiobjectversion = table.Column<string>(name: "wmi_object_version", type: "text", nullable: false),
                    wmiobjectcaption = table.Column<string>(name: "wmi_object_caption", type: "text", nullable: false),
                    clouddeploysupport = table.Column<bool>(name: "cloud_deploy_support", type: "boolean", nullable: false),
                    scriptinstall = table.Column<string>(name: "script_install", type: "text", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "executable_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_executable_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exploit_reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    exploitid = table.Column<string>(name: "exploit_id", type: "text", nullable: false),
                    reporttitle = table.Column<string>(name: "report_title", type: "text", nullable: false),
                    reporttext = table.Column<string>(name: "report_text", type: "text", nullable: false),
                    datereported = table.Column<string>(name: "date_reported", type: "text", nullable: false),
                    appliesto = table.Column<string[]>(name: "applies_to", type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exploit_reports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lcid_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lcid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lcid_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "locale_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provider = table.Column<string>(type: "text", nullable: false),
                    providercode = table.Column<string>(name: "provider_code", type: "text", nullable: false),
                    provideruid = table.Column<string>(name: "provider_uid", type: "text", nullable: false),
                    providerxft = table.Column<string>(name: "provider_xft", type: "text", nullable: false),
                    provideruserid = table.Column<string>(name: "provider_user_id", type: "text", nullable: false),
                    providerpasswd = table.Column<string>(name: "provider_passwd", type: "text", nullable: false),
                    providerext1 = table.Column<string>(name: "provider_ext1", type: "text", nullable: false),
                    providerext2 = table.Column<string>(name: "provider_ext2", type: "text", nullable: false),
                    providerext3 = table.Column<string>(name: "provider_ext3", type: "text", nullable: false),
                    providerext4 = table.Column<string>(name: "provider_ext4", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locale_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "locales",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lookup = table.Column<string>(name: "look_up", type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    transfermethod = table.Column<int>(name: "transfer_method", type: "integer", nullable: true),
                    host = table.Column<string>(type: "text", nullable: true),
                    port = table.Column<int>(type: "integer", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news_updates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    articleimage = table.Column<string>(name: "article_image", type: "text", nullable: false),
                    articleheading = table.Column<string>(name: "article_heading", type: "text", nullable: false),
                    articlepreview = table.Column<string>(name: "article_preview", type: "text", nullable: false),
                    articlelink = table.Column<string>(name: "article_link", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news_updates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_managements",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    accountid = table.Column<int>(name: "account_id", type: "integer", nullable: false),
                    orderdate = table.Column<string>(name: "order_date", type: "text", nullable: false),
                    orderstatus = table.Column<string>(name: "order_status", type: "text", nullable: false),
                    ordername = table.Column<string>(name: "order_name", type: "character varying(20)", maxLength: 20, nullable: false),
                    downloadlink = table.Column<string>(name: "download_link", type: "text", nullable: true),
                    imageoutputformat = table.Column<string>(name: "image_output_format", type: "text", nullable: true),
                    notificationemailaddress = table.Column<string>(name: "notification_email_address", type: "text", nullable: false),
                    continuousintegration = table.Column<bool>(name: "continuous_integration", type: "boolean", nullable: false),
                    continuousdelivery = table.Column<bool>(name: "continuous_delivery", type: "boolean", nullable: false),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false),
                    arch = table.Column<string>(type: "text", nullable: false),
                    lcid = table.Column<string>(type: "text", nullable: false),
                    optionalfeaturestring = table.Column<string>(name: "optional_feature_string", type: "text", nullable: true),
                    appxpackagesstring = table.Column<string>(name: "appx_packages_string", type: "text", nullable: true),
                    windowsdefaultaccount = table.Column<string>(name: "windows_default_account", type: "character varying(20)", maxLength: 20, nullable: false),
                    windowsdefaultpassword = table.Column<string>(name: "windows_default_password", type: "text", nullable: false),
                    customregistrykeys = table.Column<string[]>(name: "custom_registry_keys", type: "text[]", nullable: false),
                    applicationuid = table.Column<string[]>(name: "application_uid", type: "text[]", nullable: false),
                    driversuid = table.Column<string[]>(name: "drivers_uid", type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_managements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "original_equipment_manufacturer_contacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    originalequipmentmanufacturer = table.Column<string>(name: "original_equipment_manufacturer", type: "text", nullable: false),
                    countryzone = table.Column<string>(name: "country_zone", type: "text", nullable: true),
                    oemname = table.Column<string>(name: "oem_name", type: "text", nullable: false),
                    contactperson = table.Column<string>(name: "contact_person", type: "text", nullable: true),
                    contactphone = table.Column<string>(name: "contact_phone", type: "text", nullable: true),
                    contactemail = table.Column<string>(name: "contact_email", type: "text", nullable: true),
                    oemwebsite = table.Column<string>(name: "oem_website", type: "text", nullable: false),
                    supportphone = table.Column<string>(name: "support_phone", type: "text", nullable: true),
                    supportphonehours = table.Column<string>(name: "support_phone_hours", type: "text", nullable: true),
                    supportemail = table.Column<string>(name: "support_email", type: "text", nullable: true),
                    supportwebsite = table.Column<string>(name: "support_website", type: "text", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_original_equipment_manufacturer_contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "package_detection_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    method = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_package_detection_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "registry_keys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    registryhive = table.Column<int>(name: "registry_hive", type: "integer", nullable: false),
                    key = table.Column<string>(type: "text", nullable: false),
                    subkey = table.Column<string>(type: "text", nullable: false),
                    valuename = table.Column<string>(name: "value_name", type: "text", nullable: false),
                    valuetype = table.Column<int>(name: "value_type", type: "integer", nullable: false),
                    valuedata = table.Column<string>(name: "value_data", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_registry_keys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transfer_method_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    method = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transfer_method_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "uninstall_process_indices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    method = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_uninstall_process_indices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "virus_total_scans",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    hashscanned = table.Column<string>(name: "hash_scanned", type: "text", nullable: false),
                    filename = table.Column<string>(type: "text", nullable: false),
                    uriscanned = table.Column<string>(name: "uri_scanned", type: "text", nullable: false),
                    uriscanid = table.Column<string>(name: "uri_scan_id", type: "text", nullable: false),
                    tlsh = table.Column<string>(type: "text", nullable: false),
                    vhash = table.Column<string>(type: "text", nullable: false),
                    statsharmless = table.Column<int>(name: "stats_harmless", type: "integer", nullable: false),
                    statstypeunsupported = table.Column<int>(name: "stats_type_unsupported", type: "integer", nullable: false),
                    statssuspicious = table.Column<int>(name: "stats_suspicious", type: "integer", nullable: false),
                    statsconfirmedtimeout = table.Column<int>(name: "stats_confirmed_timeout", type: "integer", nullable: false),
                    statstimeout = table.Column<int>(name: "stats_timeout", type: "integer", nullable: false),
                    statsfailure = table.Column<int>(name: "stats_failure", type: "integer", nullable: false),
                    statsmalicious = table.Column<int>(name: "stats_malicious", type: "integer", nullable: false),
                    statsundetected = table.Column<int>(name: "stats_undetected", type: "integer", nullable: false),
                    statstotalcount = table.Column<int>(name: "stats_total_count", type: "integer", nullable: false),
                    statssafetypercentage = table.Column<int>(name: "stats_safety_percentage", type: "integer", nullable: false),
                    issafe = table.Column<bool>(name: "is_safe", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_virus_total_scans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "win_ref_core01releases",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    release = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_win_ref_core01releases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "win_ref_core02editions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_win_ref_core02editions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "win_ref_core03versions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_win_ref_core03versions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "win_ref_core04arches",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false),
                    arch = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_win_ref_core04arches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "win_ref_core05languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false),
                    arch = table.Column<string>(type: "text", nullable: false),
                    language = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_win_ref_core05languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "windows_capabilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    present = table.Column<bool>(type: "boolean", nullable: false),
                    supportedwindowsversions = table.Column<string[]>(name: "supported_windows_versions", type: "text[]", nullable: false),
                    supportedwindowseditions = table.Column<string[]>(name: "supported_windows_editions", type: "text[]", nullable: false),
                    supportedwindowsreleases = table.Column<string[]>(name: "supported_windows_releases", type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_windows_capabilities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "windows_core_identities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    uid = table.Column<string>(type: "text", nullable: false),
                    release = table.Column<string>(type: "text", nullable: false),
                    edition = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false),
                    build = table.Column<string>(type: "text", nullable: false),
                    arch = table.Column<string>(type: "text", nullable: false),
                    windowslcid = table.Column<string>(name: "windows_lcid", type: "text", nullable: false),
                    supporteduntil = table.Column<string>(name: "supported_until", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_windows_core_identities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "windows_optional_features",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: true),
                    featurename = table.Column<string>(name: "feature_name", type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    supportedwindowsversions = table.Column<string[]>(name: "supported_windows_versions", type: "text[]", nullable: false),
                    supportedwindowseditions = table.Column<string[]>(name: "supported_windows_editions", type: "text[]", nullable: false),
                    supportedwindowsreleases = table.Column<string[]>(name: "supported_windows_releases", type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_windows_optional_features", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_category_indices");

            migrationBuilder.DropTable(
                name: "application_packages");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "appx_provisioned_packages");

            migrationBuilder.DropTable(
                name: "base_image_file_type_indices");

            migrationBuilder.DropTable(
                name: "base_images");

            migrationBuilder.DropTable(
                name: "country_indices");

            migrationBuilder.DropTable(
                name: "cpu_arch_indices");

            migrationBuilder.DropTable(
                name: "driver_cores");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "executable_indices");

            migrationBuilder.DropTable(
                name: "exploit_reports");

            migrationBuilder.DropTable(
                name: "lcid_indices");

            migrationBuilder.DropTable(
                name: "locale_indices");

            migrationBuilder.DropTable(
                name: "locales");

            migrationBuilder.DropTable(
                name: "news_updates");

            migrationBuilder.DropTable(
                name: "order_managements");

            migrationBuilder.DropTable(
                name: "original_equipment_manufacturer_contacts");

            migrationBuilder.DropTable(
                name: "package_detection_indices");

            migrationBuilder.DropTable(
                name: "registry_keys");

            migrationBuilder.DropTable(
                name: "transfer_method_indices");

            migrationBuilder.DropTable(
                name: "uninstall_process_indices");

            migrationBuilder.DropTable(
                name: "virus_total_scans");

            migrationBuilder.DropTable(
                name: "win_ref_core01releases");

            migrationBuilder.DropTable(
                name: "win_ref_core02editions");

            migrationBuilder.DropTable(
                name: "win_ref_core03versions");

            migrationBuilder.DropTable(
                name: "win_ref_core04arches");

            migrationBuilder.DropTable(
                name: "win_ref_core05languages");

            migrationBuilder.DropTable(
                name: "windows_capabilities");

            migrationBuilder.DropTable(
                name: "windows_core_identities");

            migrationBuilder.DropTable(
                name: "windows_optional_features");
        }
    }
}
