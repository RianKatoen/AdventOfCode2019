map <- readLines("data.txt");

remaining.orbits <- strsplit(map, ")");
previous.orbits <- c("COM");

n.orbits <- 0;
orbit.level <- 1;

while(length(remaining.orbits) > 0) {
  current.orbits <- sapply(remaining.orbits, function(x) x[1] %in% previous.orbits);
  n.orbits <- n.orbits + orbit.level * sum(current.orbits);
  previous.orbits <- sapply(remaining.orbits[current.orbits], function(x) x[2]);
  remaining.orbits <- remaining.orbits[!current.orbits];
  cat("Orbit level: ", orbit.level, "; Number of planets on this level: ", sum(current.orbits), "Remaining planets: ", length(remaining.orbits), "\n");
  orbit.level <- orbit.level + 1;
}