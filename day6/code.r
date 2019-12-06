# Read data.
map <- readLines("data.txt");

# Initialize the while loop by defining the remaining orbits as start orbits and previous orbits as "Centre of Mass".
remaining.orbits <- strsplit(map, ")");
previous.orbits <- c("COM");

# Start with no orbits... :)
n.orbits <- 0;
# The first level of orbits will have only a direct orbit.
orbit.level <- 1;

while(length(remaining.orbits) > 0) {
  # Find out all planets who orbit the planets of the previous level.
  current.orbits <- sapply(remaining.orbits, function(x) x[1] %in% previous.orbits);
  
  # Add the number of orbits find on the current level to the total.
  n.orbits <- n.orbits + orbit.level * sum(current.orbits);
  
  # Store all the planets orbiting the previous level.
  previous.orbits <- sapply(remaining.orbits[current.orbits], function(x) x[2]);
  
  # Remove all the planets that orbit in the current level.
  remaining.orbits <- remaining.orbits[!current.orbits];
  
  # Print some fancy stuff.
  cat("Orbit level: ", orbit.level, "; Number of planets on this level: ", sum(current.orbits), "Remaining planets: ", length(remaining.orbits), "\n");
  
  # All orbits following this iteration will have one extra indirect orbit.
  orbit.level <- orbit.level + 1;
}