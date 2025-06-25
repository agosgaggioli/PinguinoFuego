import pygame
from lib.Var import WIDTH, HEIGHT, PUNTAJE, VIDA
from lib.Color import BLACK, WHITE, GREEN
from lib.Core import Player, BolaFuego


pygame.init()
pygame.mixer.init()

screen = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption("Pingüino en Llamas")
clock = pygame.time.Clock()

# Sonidos
nieve_sonido = pygame.mixer.Sound("assets/sonidos/DisparoBola.wav")
derretir_sonido = pygame.mixer.Sound("assets/sonidos/impactoNieve.wav")
pygame.mixer.music.load("assets/sonidos/MusicaFondo.ogg")
pygame.mixer.music.set_volume(0.1)
pygame.mixer.music.play(loops=-1)

# Fondo
fondo = pygame.image.load("Sprite/Fondos/oceano.png").convert()

def draw_text(surface, text, size, x, y):
    font = pygame.font.SysFont('Arial', size)
    text_surface = font.render(text, True, BLACK)
    text_rect = text_surface.get_rect()
    text_rect.midtop = (x, y)
    surface.blit(text_surface, text_rect)

def draw_vida(surface, x, y, porcentaje):
    BAR_LENGHT = 100
    BAR_HEIGHT = 10
    fill = (porcentaje / 100) * BAR_LENGHT
    fill_rect = pygame.Rect(x, y, fill, BAR_HEIGHT)
    border_rect = pygame.Rect(x, y, BAR_LENGHT, BAR_HEIGHT)
    pygame.draw.rect(surface, GREEN, fill_rect)
    pygame.draw.rect(surface, WHITE, border_rect, 2)

def show_go_screen():
    screen.blit(fondo, (0, 0))
    draw_text(screen, "Pingüino en Llamas", 65, WIDTH // 2, HEIGHT // 4)
    draw_text(screen, "El clima está en tus manos", 27, WIDTH // 2, HEIGHT // 2)
    draw_text(screen, "Presiona una tecla para comenzar", 22, WIDTH // 2, HEIGHT * 3 / 4)
    pygame.display.flip()
    waiting = True
    while waiting:
        clock.tick(60)
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()
            if event.type == pygame.KEYUP:
                waiting = False

# Lógica principal del juego
game_over = True
running = True

while running:
    if game_over:
        show_go_screen()
        VIDA = 100
        PUNTAJE = 0
        all_sprites = pygame.sprite.Group()
        all_bolas = pygame.sprite.Group()
        all_Nieves = pygame.sprite.Group()
        player = Player()
        all_sprites.add(player)
        for i in range(8):
            bola = BolaFuego()
            all_sprites.add(bola)
            all_bolas.add(bola)
        game_over = False

    clock.tick(60)
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_SPACE:
                player.shoot(all_sprites, all_Nieves, nieve_sonido)

    all_sprites.update()

    # Colisiones
    colisiones = pygame.sprite.groupcollide(all_bolas, all_Nieves, True, True)
    for _ in colisiones:
        PUNTAJE += 1
        derretir_sonido.play()
        bola = BolaFuego()
        all_sprites.add(bola)
        all_bolas.add(bola)

    hits = pygame.sprite.spritecollide(player, all_bolas, True)
    for _ in hits:
        VIDA -= 25
        bola = BolaFuego()
        all_sprites.add(bola)
        all_bolas.add(bola)
        if VIDA <= 0:
            game_over = True

    screen.blit(fondo, (0, 0))
    all_sprites.draw(screen)
    draw_text(screen, str(PUNTAJE), 25, WIDTH // 2, 10)
    draw_vida(screen, 5, 5, VIDA)
    pygame.display.flip()

pygame.quit()
