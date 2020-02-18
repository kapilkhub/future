FROM mcr.microsoft.com/dotnet/core/sdk AS build-env

#build instructions
WORKDIR c:\\docker-sample
COPY . .

RUN dotnet publish -c Release -o c:\\publish 


#runtime instructions
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR c:\\publish
COPY --from=build-env c:\\publish .


ENV ASPNETCORE_URLS http://+:80
ENTRYPOINT ["dotnet","docker-sample.dll"]


