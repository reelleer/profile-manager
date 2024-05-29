$password = 'Test#2024.'
$name = 'dbprofiles'
$tag = 'profiles'

$containerExists = docker ps -a --filter name=dbprofile --format "{{.Names}}"

if ($containerExists -eq $name) {
  # Stop the container
  docker stop $name

  # Remove the container
  docker rm $name
}

docker build --tag $tag .

docker run -dp 1433:1433 --name $name --hostname $name $tag

# Wait for the SQL Server to start up, adjust the sleep time as needed
echo "Esleeping 5s"
Start-Sleep -s 5

echo "Creating Database"
# Execute the SQL script
docker exec $name /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $password -i /app/dbProfiles.sql
