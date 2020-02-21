# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk AS build-env


WORKDIR /Sample

# restore


# RUN ls -alR
# copy source code


COPY . .

# test
ENV TEAMCITY_PROJECT_NAME=fake 
RUN dotnet test ./docker-sample/tests 

# publish
RUN dotnet publish ./docker-sample/docker-sample -o /publish

# runtime stage
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY --from=build-env /publish /publish

ENV ASPNETCORE_URLS http://+:80
WORKDIR /publish
ENTRYPOINT ["dotnet","docker-sample.dll"]