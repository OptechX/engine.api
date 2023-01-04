# for f in ./Controllers/*.cs;
# do
#     gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" \
#     --output ./appsettings.json ./appsettings.json.gpg
#   #echo -e "$LARGE_SECRET_PASSPHRASE" | gpg -c --pinentry-mode loopback --passphrase-fd 0 $f
# done

$files = Get-ChildItem -Path ./Controllers/*.cs.gpg
foreach ($f in  $files)
{
    $NewName = $($f.FullName).Replace('.gpg','')
    gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" --output $NewName $f
}