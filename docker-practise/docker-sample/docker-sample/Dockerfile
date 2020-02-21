FROM mcr.microsoft.com/dotnet/core/sdk AS build-env

#build instructions
WORKDIR /docker-sample
COPY . .

RUN dotnet publish -c Release -o /publish 


#runtime instructions
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /publish
COPY --from=build-env /publish .


ENV ASPNETCORE_URLS http://+:80
ENTRYPOINT ["dotnet","docker-sample.dll"]


