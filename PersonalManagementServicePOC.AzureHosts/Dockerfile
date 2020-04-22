FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY PersonalManagementServicePOC.AzureHosts/PersonalManagementServicePOC.AzureHosts.csproj PersonalManagementServicePOC.AzureHosts/
COPY DependencyRegistrar/DependencyRegistrar.csproj DependencyRegistrar/
COPY PersonalManagementServicePOC.Domain/PersonalManagementServicePOC.Domain.csproj PersonalManagementServicePOC.Domain/
COPY Repository.PersonalManagementServicePOC/Repository.PersonalManagementServicePOC.csproj Repository.PersonalManagementServicePOC/
COPY ../Shared/Shared/ExceptionHandling/ExceptionHandling.csproj ../Shared/Shared/ExceptionHandling/
COPY PersonalManagementServicePOC.Application1/PersonalManagementServicePOC.Application.csproj PersonalManagementServicePOC.Application1/
RUN dotnet restore PersonalManagementServicePOC.AzureHosts/PersonalManagementServicePOC.AzureHosts.csproj
COPY . .
WORKDIR /src/PersonalManagementServicePOC.AzureHosts
RUN dotnet build PersonalManagementServicePOC.AzureHosts.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PersonalManagementServicePOC.AzureHosts.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PersonalManagementServicePOC.AzureHosts.dll"]
