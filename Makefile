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
	dotnet list $(PROJECT_FILE) package
packages-list-outdated:
	dotnet list $(PROJECT_FILE) package --outdated
packages-update:
	dotnet add $(PROJECT_FILE) package PackageName --version latest

PACKAGE_NAME := $(filter-out package-add,$(MAKECMDGOALS))
%:
	@:
package-add:
	dotnet add $(PROJECT_FILE) package $(PACKAGE_NAME)

migrations-create:
	dotnet tool run dotnet-ef migrations add Init --project $(PROJECT_FILE)
migrations-apply:
	dotnet tool run dotnet-ef database update --project $(PROJECT_FILE)
migrations-status:
	dotnet ef migrations list --project $(PROJECT_FILE)

secrets-init:
	dotnet user-secrets init --project $(PROJECT_FILE)

