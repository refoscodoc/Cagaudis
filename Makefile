version?=0.0.1

version: 
	@echo "Version ${version}"

start: start-native

start-native: 
	@echo "Starting the API Services" 
	@mkdir -p .docker-data 
#	@rm -rf meta/registry-services.local.json && cp meta/templates/registry-services-local.json meta/registry-services.local.json 
	@docker-compose -f docker-compose.yml -f docker-compose.traefik.yml -f docker-compose.ports.yml up audit-service mariadb cars-service traefik 
	@docker-compose logs -f backend traefik