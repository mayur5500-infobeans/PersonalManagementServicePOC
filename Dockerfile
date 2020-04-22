FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
#FROM mcr.microsoft.com/dotnet/core/runtime:2.2.17-bionic AS base
#mcr.microsoft.com/dotnet/core/sdk
WORKDIR /app

#FROM mcr.microsoft.com/dotnet/core/sdk:2.1.805-bionic AS build
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY PersonalManagementServicePOC.SelfHosting/PersonalManagementServicePOC.SelfHosting.csproj PersonalManagementServicePOC.SelfHosting/
COPY DependencyRegistrar/DependencyRegistrar.csproj DependencyRegistrar/
COPY PersonalManagementServicePOC.Domain/PersonalManagementServicePOC.Domain.csproj PersonalManagementServicePOC.Domain/
COPY Repository.PersonalManagementServicePOC/Repository.PersonalManagementServicePOC.csproj Repository.PersonalManagementServicePOC/
COPY ../Shared/Shared/ExceptionHandling/ExceptionHandling.csproj ../Shared/Shared/ExceptionHandling/
COPY PersonalManagementServicePOC.Application1/PersonalManagementServicePOC.Application.csproj PersonalManagementServicePOC.Application1/
RUN dotnet restore PersonalManagementServicePOC.SelfHosting/PersonalManagementServicePOC.SelfHosting.csproj
COPY . .
WORKDIR /src/PersonalManagementServicePOC.SelfHosting
RUN dotnet build PersonalManagementServicePOC.SelfHosting.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PersonalManagementServicePOC.SelfHosting.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PersonalManagementServicePOC.SelfHosting.dll"]
