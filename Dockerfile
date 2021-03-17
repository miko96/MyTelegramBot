FROM mcr.microsoft.com/dotnet/runtime:3.1

EXPOSE 80

WORKDIR /app

COPY ./publish .

ENTRYPOINT ["dotnet", "MyTelegramBot.dll"]