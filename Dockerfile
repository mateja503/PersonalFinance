# Base image for final runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy and restore the main project
COPY ["PersonalFinanceWeb/PersonalFinanceWeb.csproj", "PersonalFinanceWeb/"]
RUN dotnet restore "PersonalFinanceWeb/PersonalFinanceWeb.csproj"

# Copy the rest of the solution
COPY . .

# Install EF Core CLI
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Wait for SQL Server (temporary script workaround)
#COPY ./wait-for-sql.sh .
#RUN chmod +x wait-for-sql.sh


# Build
WORKDIR "/src/PersonalFinanceWeb"
RUN dotnet build "PersonalFinanceWeb.csproj" -c Release -o /app/build

# Run EF Core migrations
#ENV SA_PASSWORD="Tgsv*HJEiCT2bpf"
#ENV DB_CONNECTION="Server=db;Database=PersonalFinanceDb_part2;User ID=sa;Password=Tgsv*HJEiCT2bpf;TrustServerCertificate=True;Encrypt=True"
#RUN ../wait-for-sql.sh db 1433 -- \
 # dotnet ef database update --no-build --connection "$DB_CONNECTION"
 
#RUN dotnet ef database update --no-build --connection "$DB_CONNECTION"


#Pubilsh
RUN dotnet publish "PersonalFinanceWeb.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV PLACEHOLDER_ENV=""

CMD []

# Entry point
ENTRYPOINT ["dotnet", "PersonalFinanceWeb.dll"]
