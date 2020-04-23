FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
#COPY ./*.sln ./
#COPY ./*/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
#COPY ../ ./
COPY ./PersonalManagementServicePOC.SelfHosting/PersonalManagementServicePOC.SelfHosting.csproj ./PersonalManagementServicePOC.SelfHosting/
COPY ./DependencyRegistrar/DependencyRegistrar.csproj ./DependencyRegistrar/
COPY ./PersonalManagementServicePOC.Domain/PersonalManagementServicePOC.Domain.csproj ./PersonalManagementServicePOC.Domain/
COPY ./Repository.PersonalManagementServicePOC/Repository.PersonalManagementServicePOC.csproj ./Repository.PersonalManagementServicePOC/
COPY ./Shared/Shared/ExceptionHandling/ExceptionHandling.csproj ./Shared/Shared/ExceptionHandling/
COPY ./PersonalManagementServicePOC.Application1/PersonalManagementServicePOC.Application.csproj ./PersonalManagementServicePOC.Application1/
COPY ./PersonalManagementServicePOC.NUnitTestProject/PersonalManagementServicePOC.NUnitTestProject.csproj ./PersonalManagementServicePOC.NUnitTestProject/
COPY ./PersonalManagementServicePOC.AzureHosts/PersonalManagementServicePOC.AzureHosts.csproj ./PersonalManagementServicePOC.AzureHosts/
COPY ./Repository.PersonalManagementServicePOC.Tests/Repository.PersonalManagementServicePOC.Tests.csproj ./Repository.PersonalManagementServicePOC.Tests/
COPY ./PersonalManagementServicePOC.Domain.Tests/PersonalManagementServicePOC.Domain.Tests.csproj ./PersonalManagementServicePOC.Domain.Tests/
COPY ./PersonalManagementServicePOC.Application.Tests/PersonalManagementServicePOC.Application.Tests.csproj ./PersonalManagementServicePOC.Application.Tests/
COPY ./docker-compose.dcproj ./
COPY ./PersonalManagementServicePOC.sln .
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
