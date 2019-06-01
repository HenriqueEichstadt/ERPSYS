#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1803 AS build
WORKDIR /src
COPY ["ERPSYS.MVC/ERPSYS.MVC.csproj", "ERPSYS.MVC/"]
RUN dotnet restore "ERPSYS.MVC/ERPSYS.MVC.csproj"
COPY . .
WORKDIR "/src/ERPSYS.MVC"
RUN dotnet build "ERPSYS.MVC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ERPSYS.MVC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ERPSYS.MVC.dll"]