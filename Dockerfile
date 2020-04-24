FROM microsoft/dotnet:2.2-sdk as build-image
 
WORKDIR /home/app
 
#COPY ./*.sln ./
#COPY ./*/*.csproj ./
#RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done

COPY ./PersonalManagementServicePOC.SelfHosting/PersonalManagementServicePOC.SelfHosting.csproj ./PersonalManagementServicePOC.SelfHosting/
COPY ./PersonalManagementServicePOC.Domain/PersonalManagementServicePOC.Domain.csproj ./PersonalManagementServicePOC.Domain/
COPY ./Repository.PersonalManagementServicePOC/Repository.PersonalManagementServicePOC.csproj ./Repository.PersonalManagementServicePOC/
COPY ./Shared/Shared/ExceptionHandling/ExceptionHandling.csproj ./Shared/Shared/ExceptionHandling/
COPY ./PersonalManagementServicePOC.Application1/PersonalManagementServicePOC.Application.csproj ./PersonalManagementServicePOC.Application1/
COPY ./DependencyRegistrar/DependencyRegistrar.csproj ./DependencyRegistrar/
COPY ./PersonalManagementServicePOC.NUnitTestProject/PersonalManagementServicePOC.NUnitTestProject.csproj ./PersonalManagementServicePOC.NUnitTestProject/
COPY ./PersonalManagementServicePOC.AzureHosts/PersonalManagementServicePOC.AzureHosts.csproj ./PersonalManagementServicePOC.AzureHosts/
COPY ./Repository.PersonalManagementServicePOC.Tests/Repository.PersonalManagementServicePOC.Tests.csproj ./Repository.PersonalManagementServicePOC.Tests/
COPY ./PersonalManagementServicePOC.Domain.Tests/PersonalManagementServicePOC.Domain.Tests.csproj ./PersonalManagementServicePOC.Domain.Tests/
COPY ./PersonalManagementServicePOC.Application.Tests/PersonalManagementServicePOC.Application.Tests.csproj ./PersonalManagementServicePOC.Application.Tests/
#COPY ./docker-compose.dcproj ./
COPY ./PersonalManagementServicePOC.sln .
#RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore PersonalManagementServicePOC.SelfHosting/PersonalManagementServicePOC.SelfHosting.csproj
 
COPY . .
 
RUN dotnet publish ./PersonalManagementServicePOC.SelfHosting/PersonalManagementServicePOC.SelfHosting.csproj -o /publish/
 
FROM microsoft/dotnet:2.2-aspnetcore-runtime
 
WORKDIR /publish
 
COPY --from=build-image /publish .

ENTRYPOINT ["dotnet", "PersonalManagementServicePOC.SelfHosting.dll"]