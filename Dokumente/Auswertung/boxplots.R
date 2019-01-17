#install.packages("ggplot2")
library(ggplot2)

data <- read.csv("DatenTab.csv",sep = ';')
View(data)

challenge <- c('F9', 'F10', 'F17')
competence <- c('F2', 'F11', 'F12')
flow <- c('F5', 'F8', 'F20')
immersion <- c('F4', 'F15', 'F21')
negEff <- c('F3', 'F6', 'F16')
posEff <- c('F1', 'F13', 'F14')
tension <- c('F7', 'F18', 'F19')
control <- c('F22')

data$Challenge <- rowMeans(data[,challenge])
data$Competence <- rowMeans(data[,competence])
data$Flow <- rowMeans(data[,flow])
data$Immersion <- rowMeans(data[,immersion])
data$NegEff <- rowMeans(data[,negEff])
data$PosEff <- rowMeans(data[,posEff])
data$Tension <- rowMeans(data[,tension])
data$Control <- rowMeans(data[,control])

# Kategorie 1 (Challenge)

lmts <- c(0,4)

#par(mfrow = c(1,2))
#boxplot(challenge_Top, ylim=lmts, main="TopDown")
#boxplot(challenge_Third, ylim=lmts, main="ThirdPerson")


ggplot(data, aes(x = FirstGame, y = Tension, fill = FirstGame)) +
facet_wrap(~ Game) +
theme_bw() +
geom_boxplot() +
labs( y = 'Rating', x = 'Perspektive', title= 'Tension')



# Kategorie 2 (Competence)

# Kategorie 3 (Flow)
				
# Kategorie 4 (Immersion)
immersion_Top <- c(3,4,4,0,4,
				   2,2,2,3,
				   0,2,4,1,1)
immersion_Third <- c(3,3,4,4,4,
					 3,2,4,4,3,
					 1,2,4,4,2)
					 
# Kategorie 5 (Negative Effect)
neg_Top <- c(0,0,0,0,0,
			 0,0,0,4,0,
			 0,0,0,0,0)
neg_Third <- c(0,0,0,0,0,
			   0,0,1,0,0,
			   0,2,0,0,0)

# Kategorie 6 (Positive Effect)
pos_Top <- c(0,1,0,1,4,
			 4,4,4,0,4,
			 4,4,4,0,4)
pos_Third <- c(1,2,0,3,2,
			   3,3,4,4,4,
			   4,4,4,4,4)

# Kategorie 7 (Tension)
tension_Top <- c(0,0,0,0,0,
				 0,0,0,1,
				 2,4,0,4,1)
tension_Third <- c(0,1,0,0,0,
				   2,1,0,0,0,
				   1,0,0,0,1)
				   
# Steuerungs Frage
control_Top <- c(1,4,1,0,2)
control_Third <- c(4,4,4,0,1)
