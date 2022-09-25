docker build -t brunoritter123/techpet:lastest .
docker push brunoritter123/techpet:lastest

$env:ASPNETCORE_ENVIRONMENT = 'Production'
dotnet ef database update --project ./TechPet.Identity/ --startup-project ./TechPet.API/ --context IdentityContext
dotnet ef database update --project ./TechPet.Data/ --startup-project ./TechPet.API/ --context TechPetContext