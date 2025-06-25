import pygame
import random
from lib.Var import WIDTH, HEIGHT
from lib.Color import BLACK, GREEN, WHITE

class Player(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        try:
            self.image = pygame.image.load("Sprite/Personaje/pinguino.png").convert()
            self.image = pygame.transform.scale(self.image, (100, 100))
            self.image.set_colorkey(BLACK)
        except:
            print("Error al cargar la imagen del pingüino.")
            self.image = pygame.Surface((75, 75))
            self.image.fill(BLACK)
        self.rect = self.image.get_rect()
        self.rect.centerx = WIDTH // 2
        self.rect.bottom = HEIGHT - 10
        self.speed_x = 0

    def update(self):
        self.speed_x = 0
        keystate = pygame.key.get_pressed()
        if keystate[pygame.K_LEFT]:
            self.speed_x = -5
        if keystate[pygame.K_RIGHT]:
            self.speed_x = 5
        self.rect.x += self.speed_x
        self.rect.right = min(WIDTH, self.rect.right)
        self.rect.left = max(0, self.rect.left)

    def shoot(self, all_sprites, all_Nieves, nieve_sonido):
        bolaNieve = BolaNieve(self.rect.centerx, self.rect.top)
        all_sprites.add(bolaNieve)
        all_Nieves.add(bolaNieve)
        nieve_sonido.play()

class BolaFuego(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = pygame.image.load("Sprite/Enemigos/BolaFuego1.png").convert()
        self.image = pygame.transform.scale(self.image, (100, 100))
        self.image.set_colorkey(BLACK)
        self.rect = self.image.get_rect()
        self.rect.x = random.randrange(WIDTH - self.rect.width)
        self.rect.y = random.randrange(-100, -40)
        self.speedy = random.randrange(1, 10)
        self.speedx = random.randrange(-5, 5)

    def update(self):
        self.rect.y += self.speedy
        self.rect.x += self.speedx
        if self.rect.top > HEIGHT + 10 or self.rect.left < -25 or self.rect.right > WIDTH + 25:
            self.__init__()

class BolaNieve(pygame.sprite.Sprite):
    def __init__(self, x, y):
        super().__init__()
        self.image = pygame.image.load("Sprite/Proyectiles/BolaNieve.png").convert()
        self.image = pygame.transform.scale(self.image, (20, 20))
        self.image.set_colorkey(BLACK)
        self.rect = self.image.get_rect()
        self.rect.centerx = x
        self.rect.y = y
        self.speedy = -10

    def update(self):
        self.rect.y += self.speedy
        if self.rect.bottom < 0:
            self.kill()