PROJECT_FILE = ./FinShark.API/FinShark.API.csproj

up:
	docker compose up -d
down:
	docker compose down
check:
	dotnet format --verify-no-changes
check-fix:
	dotnet format
packages-list:
	dotnet list package
packages-list-outdated:
	dotnet list package --outdated
packages-update:
	dotnet add package PackageName --version latest

PACKAGE_NAME := $(filter-out package-add,$(MAKECMDGOALS))
%:
	@:
package-add:
	dotnet add $(PROJECT_FILE) package $(PACKAGE_NAME)

migrations-create:
	dotnet tool run dotnet-ef migrations add Init --project $(PROJECT_FILE)
