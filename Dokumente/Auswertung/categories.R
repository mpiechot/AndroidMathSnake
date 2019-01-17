library(ggplot2)

data <- read.csv("KategoriesPlot2.csv",sep = ';')
View(data)


ggplot(data, aes(x = Kategorie, y = Mean, fill= Game)) +
  facet_grid(~ Game) +
  #geom_hline(yintercept = 3, size=1.5) +
  theme_bw() +
  geom_boxplot(stat = "boxplot") +
  labs( y = 'Rating', x = 'Perspektive', title= 'Tension')

ggplot(data, aes(Kategorie,Mean), fill=Kategorie, ylim(c(1:3)))  +  geom_boxplot(fatten=6) +
  stat_boxplot(geom ='errorbar') + 
  #geom_hline(yintercept = 3, size=1.5)  + 
  scale_x_discrete("Subscales of the Game Experience Questionnaire (GEQ)") +   
  theme_gray(base_size = 45) +  
  theme(axis.text.x=element_text(angle =22.5, hjust = 1)) + scale_y_continuous(name="Rating")