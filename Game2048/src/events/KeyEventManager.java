package events;

import javax.swing.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by dimap on 10/14/2015.
 */
public class KeyEventManager implements KeyListener{
    private static KeyEventManager ourInstance = new KeyEventManager();
    private static List<KeyEventListener> listKeyEventListeners = new ArrayList<KeyEventListener>();

    public static KeyEventManager getInstance() {
        return ourInstance;
    }

    public KeyEventManager() {
    }

    @Override
    public void keyTyped(KeyEvent e) {

    }

    @Override
    public void keyPressed(KeyEvent e) {
        switch(e.getKeyCode())
        {
            case KeyEvent.VK_DOWN:
            {
                for (KeyEventListener listener : listKeyEventListeners) {
                    listener.keyDownPressed();
                }
                break;
            }
            case KeyEvent.VK_UP:
            {
                for (KeyEventListener listener : listKeyEventListeners) {
                    listener.keyUpPressed();
                }
                break;
            }
            case KeyEvent.VK_RIGHT:
            {
                for (KeyEventListener listener : listKeyEventListeners) {
                    listener.keyRightPressed();
                }
                break;
            }
            case KeyEvent.VK_LEFT:
            {
                for (KeyEventListener listener : listKeyEventListeners) {
                    listener.keyLeftPressed();
                }
                break;
            }
        }
    }

    @Override
    public void keyReleased(KeyEvent e) {

    }

    public void addKeyEventListener(KeyEventListener listener){
        listKeyEventListeners.add(listener);
    }
}
