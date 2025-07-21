PROJECT_FILE = ./FinShark.API/FinShark.API.csproj

install:
	make env
	make restore
	make up
	make migrations-apply

env:
	test -f .env || cp .env.example .env
up:
	docker compose up -d
down:
	docker compose down
check:
	dotnet format --verify-no-changes
check-fix:
	dotnet format
test:
	dotnet test
packages-list:
	dotnet list $(PROJECT_FILE) package
packages-list-outdated:
	dotnet list $(PROJECT_FILE) package --outdated
packages-update:
	dotnet add $(PROJECT_FILE) package PackageName --version latest
restore:
	dotnet restore $(PROJECT_FILE)

PACKAGE_NAME := $(filter-out package-add,$(MAKECMDGOALS))
%:
	@:
package-add:
	dotnet add $(PROJECT_FILE) package $(PACKAGE_NAME)

MIGRATION_NAME := $(filter-out migrations-create,$(MAKECMDGOALS))
%:
	@:
migrations-create:
	dotnet tool run dotnet-ef migrations add $(MIGRATION_NAME) --project $(PROJECT_FILE)
migrations-apply:
	dotnet tool run dotnet-ef database update --project $(PROJECT_FILE)
migrations-status:
	dotnet ef migrations list --project $(PROJECT_FILE)

secrets-init:
	dotnet user-secrets init --project $(PROJECT_FILE)
