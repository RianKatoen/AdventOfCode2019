# Read data.
map <- readLines("data.txt");
orbits <- strsplit(map, ")");

# Function to determine the ancestors of a given planet.
planet.ancestors <- function(orbits, planet){
  ancestors <- c();
  while(planet != "COM"){
    planet <- orbits[sapply(orbits, function(x) x[2] == planet)][[1]][1];
    ancestors <- c(planet, ancestors)
  }
  ancestors
}

# Retrieve all ancestors for "YOU".
you.ancestors <- planet.ancestors(orbits, "YOU");
# Orbital level of "YOU".
you.orbit.level <- length(you.ancestors);

# Retrieve all ancestors for "SAN".
san.ancestors <- planet.ancestors(orbits, "SAN");
# Orbital level of "SAN".
san.orbit.level <- length(san.ancestors);

# Create vector of smallest size that has both orbital levels of "YOU" and "SAN".
min.orbit.levels <- 1:min(you.orbit.level, san.orbit.level);
# Get the highest orbital level which is a common ancestor of both "YOU" and "SAN"
common.ancestor.orbit.level <- max(which(you.ancestors[min.orbit.levels] == san.ancestors[min.orbit.levels]));

# Determine the orbital transfers needed to get from the common ancestor to "YOU" and "SAN".
min.orbit.transfers <- (you.orbit.level - common.ancestor.orbit.level) + (san.orbit.level - common.ancestor.orbit.level);