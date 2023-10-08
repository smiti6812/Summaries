# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /Summaries
<Exec WorkingDirectory="$(SpaRoot)" Command="npm install" /> 
COPY Summaries/*.csproj .
RUN dotnet restore
COPY Summaries .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Summaries.dll"]
