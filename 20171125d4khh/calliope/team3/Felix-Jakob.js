let Platzhalter = 0
input.onGesture(Gesture.Shake, () => {
    Platzhalter = Math.random(6)
    Platzhalter += 1
    basic.showNumber(Platzhalter)
    if (6 == Platzhalter) {
        music.playTone(523, music.beat(BeatFraction.Whole))
        music.playTone(294, music.beat(BeatFraction.Whole))
        music.playTone(330, music.beat(BeatFraction.Whole))
    }
})