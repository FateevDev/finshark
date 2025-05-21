up:
	docker compose up -d
down:
	docker compose down
check:
	dotnet format --verify-no-changes
check-fix:
	dotnet format