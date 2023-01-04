#!/bin/sh

LARGE_SECRET_PASSPHRASE=x

# move the files to be decrypted to a temp folder
for x in ./Controllers/*.cs.gpg;
do
    mv $x ./_tmp_decrypt/
done

# decrypt and rename the files
for f in ./_tmp_decrypt/*.cs.gpg;
do
    NEW_NAME="${f%.cs.gpg}.cs"
    gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" --pinentry-mode loopback \
    --output $NEW_NAME $f
done

# move the decrypted files back
for x in ./_tmp_decrypt/*.cs;
do
    mv $x ./Controllers/
done

# Decrypt the appsettings.json file
gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" \
--output ./appsettings.json ./appsettings.json.gpg

# dotnet restore project
dotnet restore ./api.engine-v2.sln

# Rename project file (temp)
mv ./docker-compose.dcproj ./docker-compose.dcproj_

# Generate migrations
dotnet ef migrations add AddLookupTables

# run migrations
dotnet ef migrations database update

# Clean up
rm -rf Controllers/ApplicationCategoryIndexController.cs
rm -rf Controllers/ApplicationController.cs
rm -rf Controllers/ApplicationPackageController.cs
rm -rf Controllers/AppxProvisionedPackageController.cs
rm -rf Controllers/BaseImageController.cs
rm -rf Controllers/BaseImageFileTypeIndexController.cs
rm -rf Controllers/CountryIndexController.cs
rm -rf Controllers/CpuArchIndexController.cs
rm -rf Controllers/DriversController.cs
rm -rf Controllers/DriversCoreController.cs
rm -rf Controllers/ExecutableIndexController.cs
rm -rf Controllers/ExploitReportController.cs
rm -rf Controllers/LcidIndexController.cs
rm -rf Controllers/LocaleController.cs
rm -rf Controllers/LocaleIndexController.cs
rm -rf Controllers/NewsUpdatesController.cs
rm -rf Controllers/OrderManagementController.cs
rm -rf Controllers/OriginalEquipmentManufacturerContactController.cs
rm -rf Controllers/PackageDetectionIndexController.cs
rm -rf Controllers/RegistryKeyController.cs
rm -rf Controllers/TransferMethodIndexController.cs
rm -rf Controllers/UninstallProcessIndexController.cs
rm -rf Controllers/VirusTotalScanController.cs
rm -rf Controllers/WinRefCore01ReleaseController.cs
rm -rf Controllers/WinRefCore02EditionController.cs
rm -rf Controllers/WinRefCore03VersionController.cs
rm -rf Controllers/WinRefCore04ArchController.cs
rm -rf Controllers/WinRefCore05LanguageController.cs
rm -rf Controllers/WindowsCapabilityController.cs
rm -rf Controllers/WindowsCoreIdentityController.cs
rm -rf Controllers/WindowsOptionalFeatureController.cs
rm -rf Migrations/
rm -rf _tmp_decrypt/ApplicationCategoryIndexController.cs.gpg
rm -rf _tmp_decrypt/ApplicationController.cs.gpg
rm -rf _tmp_decrypt/ApplicationPackageController.cs.gpg
rm -rf _tmp_decrypt/AppxProvisionedPackageController.cs.gpg
rm -rf _tmp_decrypt/BaseImageController.cs.gpg
rm -rf _tmp_decrypt/BaseImageFileTypeIndexController.cs.gpg
rm -rf _tmp_decrypt/CountryIndexController.cs.gpg
rm -rf _tmp_decrypt/CpuArchIndexController.cs.gpg
rm -rf _tmp_decrypt/DriversController.cs.gpg
rm -rf _tmp_decrypt/DriversCoreController.cs.gpg
rm -rf _tmp_decrypt/ExecutableIndexController.cs.gpg
rm -rf _tmp_decrypt/ExploitReportController.cs.gpg
rm -rf _tmp_decrypt/LcidIndexController.cs.gpg
rm -rf _tmp_decrypt/LocaleController.cs.gpg
rm -rf _tmp_decrypt/LocaleIndexController.cs.gpg
rm -rf _tmp_decrypt/NewsUpdatesController.cs.gpg
rm -rf _tmp_decrypt/OrderManagementController.cs.gpg
rm -rf _tmp_decrypt/OriginalEquipmentManufacturerContactController.cs.gpg
rm -rf _tmp_decrypt/PackageDetectionIndexController.cs.gpg
rm -rf _tmp_decrypt/RegistryKeyController.cs.gpg
rm -rf _tmp_decrypt/TransferMethodIndexController.cs.gpg
rm -rf _tmp_decrypt/UninstallProcessIndexController.cs.gpg
rm -rf _tmp_decrypt/VirusTotalScanController.cs.gpg
rm -rf _tmp_decrypt/WinRefCore01ReleaseController.cs.gpg
rm -rf _tmp_decrypt/WinRefCore02EditionController.cs.gpg
rm -rf _tmp_decrypt/WinRefCore03VersionController.cs.gpg
rm -rf _tmp_decrypt/WinRefCore04ArchController.cs.gpg
rm -rf _tmp_decrypt/WinRefCore05LanguageController.cs.gpg
rm -rf _tmp_decrypt/WindowsCapabilityController.cs.gpg
rm -rf _tmp_decrypt/WindowsCoreIdentityController.cs.gpg
rm -rf _tmp_decrypt/WindowsOptionalFeatureController.cs.gpg
rm -rf appsettings.json
rm -rf bin/
rm -rf docker-compose.dcproj_
rm -rf obj/

# clean up git repo locally
git reset --hard
git clean -fxd
